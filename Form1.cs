using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

/*
 * Track changes:
 *  0.1.4   -> Added a few checks to make sure 
 *  0.1.5   -> no single quotes allowed in values in the dictionary
 *          -> textBoxInput_MouseHover text updated. Only Newick tree files are accepted as input.
 *          -> make sure the input file is in newick format -> start with a "(" and ends with a ";"
 *  0.1.6   -> fixed some bugs.
 *          -> Bad dictionary file not detected.
 *          -> Invalid renamed Newick tree file made.
 *          -> Match only full words.
 *  0.1.7   -> 2017-07-04
 *          -> Fix: won't put replacement text in quotes when it should. Input file had no quotes.
 *  0.1.8   -> Added back support for Nexus format.
 *          -> Now checks if tree file is a valid newick or nexux file (very basic check)
 *  0.1.9   -> 2017-08-31
 *          -> Added a try/catch when looking for the previous and next charaters when a key is found.
 *             In a Nexus file, sometimes there is no characters after the match.
*/


namespace batchTextReplacer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelDone.Visible = false;
        }

        private bool isDirectory(string s)
        {
            bool isIt = false;
            if (System.IO.Directory.Exists(s))
            {
                isIt = true;
                MessageBox.Show("The following entry is a directory:" + '\n' + '\n' + s,
                    "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isIt;
        }

        private void checkIO()
        {
            string dictFile = textBoxDictionary.Text;
            string inputFile = textBoxInput.Text;
            string outputFile = textBoxOutput.Text;

            //Check if all 3 textboxes are filled
            if (System.String.IsNullOrWhiteSpace(dictFile)
                || System.String.IsNullOrWhiteSpace(inputFile)
                || System.String.IsNullOrWhiteSpace(outputFile))
            {
                // if not all fields filled, show error message
                throw new InvalidDataException("Please select all the required elements.");
            }

            //Check if dictionary file exists
            if (System.IO.File.Exists(inputFile) == false)
            {
                throw new InvalidDataException("The selected dictionary file does not exist:" + '\n' + '\n' + dictFile);
            }

            //Check if input file exists
            if (System.IO.File.Exists(inputFile) == false)
            {
                throw new InvalidDataException("The selected input file does not exist:" + '\n' + '\n' + inputFile);
            }

            //Check if dictionany, input or output file is a directory
            if (isDirectory(dictFile) == true || isDirectory(inputFile) == true || isDirectory(outputFile) == true)
            {
                throw new InvalidDataException("One or more input was detected as a folder instead of a file.");
            }

            //Check that original file and renamed file names are different
            if (inputFile == outputFile)
            {
                throw new InvalidDataException("Input and output files are identical.");
            }

            //Check if output files already exists
            if (System.IO.File.Exists(outputFile) == true)
            {
                throw new InvalidDataException("The selected output file already exists:" + '\n' + '\n' + outputFile);
            }
        }

        //private Tuple <StringBuilder, bool> translate()
        private Dictionary<string, string> makeDictionary()
        {
            //Create dictionary (hash)
            Dictionary<string, string> dict = new Dictionary<string, string>();

            //read dictionary file
            using (StreamReader sr = new StreamReader(textBoxDictionary.Text))
            {
                // Counter for line number
                int line_number = 0;

                while (!sr.EndOfStream) // keep reading until the end
                {
                    line_number++;
                    string line = sr.ReadLine();
                    //Split 
                    if (!string.IsNullOrEmpty(line)) //if line not empty
                    {
                        //string[] entry = line.Replace(" ", "_").Split('\t'); //newick file format specific
                        string[] entry = line.Split('\t');
                        
                        //check if dictionary right format (two tab-separated fields)
                        if (entry.Length != 2)
                        {
                            throw new InvalidDataException("Dictionary must be a tab-separated file with 2 columns." + "\n" +
                                "Line " + line_number + " is incorrect:" + '\n' + '\n' + line);
                        }

                        string key = entry[0];
                        string value = entry[1];

                        //Check for duplicated keys
                        string item;
                        if (dict.TryGetValue(key, out item))
                        {
                            throw new InvalidDataException("Duplicated keys detected in the dictionary file:" + '\n' + '\n' + key);
                        }

                        //Make sure no key is equal to any value
                        string item2;
                        if (dict.TryGetValue(value, out item2))
                        {
                            throw new InvalidDataException("Some keys and values are identical" + '\n' + '\n' + value);
                        }

                        //Check if invalid characters (') in values
                        if (value.Contains("\'") == true)
                        {
                            throw new InvalidDataException("Key vlaues cannot contain single quote characters (\')" + '\n' + '\n' + value);
                        }

                        //Add to hash
                        dict.Add(key, value);
                    }
                }
            }

            return dict;
        }

        private StringBuilder translate(Dictionary<string, string> dict)
        {
            //String builder
            StringBuilder sb = new StringBuilder();

            //read input file
            using (StreamReader sr = new StreamReader(textBoxInput.Text))
            {
                int counter = 0;
                try
                {
                    while (!sr.EndOfStream) // keep reading until the end
                    {
                        counter++;
                        string text = sr.ReadLine(); //read on line at the time

                        //check if key has non-alpha numerical characters
                        //if so, taken for granted that it was a valid tree file,
                        //that means that the name was already in quote.
                        //Then a normal text substitution will work
                        
                        //Check if newick or nexus format
                        //There is only one line in a Newick file, but not in a nexus file
                        if (counter == 1) //fisrt line of the file
                        {
                            if (text.StartsWith("(") == false && text.StartsWith("#NEXUS") == false)
                            {
                                throw new InvalidDataException("Input file is not a valid Newick or Nexus file");
                            }
                        }

                        if (sr.EndOfStream == true)
                        {
                            if (text.EndsWith(";") == false)
                                {
                                    throw new InvalidDataException("Input file is not a valid Newick or Nexus file");
                                }
                        }

                        //if key didn
                        //check if values have non-alpha numerical character
                        //if so, add a leadind and trailing quote to the value
                        foreach (KeyValuePair<string, string> c in dict)
                        {
                            int fistLetterIndex = text.IndexOf(c.Key);
                            int lastLetterIndex = fistLetterIndex + c.Key.Length - 1;

                            // If dictionary key is not found in input file
                            if (fistLetterIndex < 0)
                            {
                                //Skip it and go to the next one
                                continue;
                            }

                            string to_find = c.Key;
                            string to_replace = c.Value;

                            // Declare variables as "null"
                            char charBefore = '\0';
                            char charAfter = '\0';

                            try
                            {
                                charBefore = text[fistLetterIndex - 1];
                            }
                            catch
                            {
                                // There is no characters before. Can this happen in a Nexus file?
                                // Do nothing
                            }

                            try
                            {
                                charAfter = text[lastLetterIndex + 1];
                            }
                            catch
                            {
                                // There is no characters after. This can happen in a Nexus file
                                // Do nothing
                            }
                            
                           
                            //if name (key) was already in quote
                            if (charBefore.ToString() == "\'" && charAfter.ToString() == "\'")
                            {
                                if (checkBoxKeepKey.Checked == true)
                                {
                                    //just replace text. Don't add quotes
                                    //text = text.Replace(c.Key, c.Value + " (" + c.Key + ')');
                                    text = Regex.Replace(text, "\\b" + c.Key + "\\b", c.Value + " (" + c.Key + ')');
                                }
                                else
                                {
                                    //text = text.Replace(c.Key, c.Value); //just replace text
                                    text = Regex.Replace(text, "\\b" + c.Key + "\\b", c.Value);  //replace whole world only, not matches that are substrings
                                }
                            }

                            // if key was not in quote
                            // and if value contains non-alphanumerical characters
                            else
                            {
                                if (checkBoxKeepKey.Checked == true)
                                {
                                    //text = text.Replace(c.Key, '\'' + c.Value + " (" + c.Key + ')' + '\'');
                                    text = Regex.Replace(text, "\\b" + c.Key + "\\b", '\'' + c.Value + " (" + c.Key + ')' + '\'');
                                }
                                else
                                {
                                    Regex rgx = new Regex("[^a-zA-Z0-9-_.]");
                                    if (rgx.IsMatch(c.Value) == true) //if non alpha numerical character are present
                                    {
                                        //add quotes
                                        //text = text.Replace(c.Key, '\'' + c.Value + '\'');
                                        text = Regex.Replace(text, "\\b" + c.Key + "\\b", '\'' + c.Value + '\'');
                                    }
                                    else
                                    {
                                        //text = text.Replace(c.Key, c.Value); //just replace text
                                        text = Regex.Replace(text, "\\b" + c.Key + "\\b", c.Value);
                                    }
                                }
                            }
                        }
                        sb.Append(text + '\n');
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return sb;
        }

        private void writeToFile(StringBuilder stingBuilderObject)
        {
            //Write result to output file
            using (StreamWriter sw = File.AppendText(textBoxOutput.Text))
            {
                sw.Write(stingBuilderObject.ToString());
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            labelDone.Visible = false;

            //perform I/O checks
            try
            {
               checkIO();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //process dictionary file
            Dictionary<string, string> dictResults = new Dictionary<string, string>();
            try
            {
                dictResults = makeDictionary();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Dictionary file", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Translate text
            StringBuilder translatedText = new StringBuilder();
            try
            {
                translatedText = translate(dictResults);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during translation of the tree file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Write translated text to file
            try
            {
                writeToFile(translatedText);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //Proceed to renaming
            //var ui = TaskScheduler.FromCurrentSynchronizationContext();
            //Task.Factory.StartNew(delegate { translate(); }, ui);

            //Show complete message
            //Check if output file exists and is not locked
            while (System.IO.File.Exists(textBoxOutput.Text) == false)
            {
                //wait
            }

            //Completion message
            labelDone.Visible = true;
        }

        private void buttonDictionary_Click(object sender, EventArgs e)
        {
            if (openFileDialogDictionary.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    textBoxDictionary.Text = openFileDialogDictionary.FileName;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (openFileDialogInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    textBoxInput.Text = openFileDialogInput.FileName;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialogOutput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    textBoxOutput.Text = saveFileDialogOutput.FileName;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void textBoxDictionary_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBoxDictionary, "A text file with two columns separated with tab:" + '\n' + '\n'
                + "key1  value1" + '\n'
                + "key2  value2" + '\n' + '\n'
                + "Where \"key\" is the text in the Input File to be replaced with the \"value\"." + '\n'
                + "Each \"key\" must be unique. Different keys may have the same value.");
        }

        private void textBoxInput_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(textBoxInput, "A tree file in Newick or Nexus format");
        }

        private void textBoxOutput_MouseHover(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(textBoxOutput, "Translated tree file to be saved");
        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip4.SetToolTip(checkBoxKeepKey, "Check if you want to keep the input file key in the translated text:" + '\n' + '\n'
                + "value1 (key1)");
        }

        private void textBoxDictionary_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxDictionary_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length != 0)
            {
                textBoxDictionary.Text = files[0];
            }
        }

        private void textBoxInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxInput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length != 0)
            {
                textBoxInput.Text = files[0];
            }
        }

        private void textBoxOutput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxOutput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length != 0)
            {
                textBoxOutput.Text = files[0];
            }
        }
    }
}
