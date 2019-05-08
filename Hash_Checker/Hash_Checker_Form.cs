using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Hash_checker
{
    public partial class Hash_Checker_Form : Form
    {
        #region Private Members:
        // Read-only members:
        /// <summary>
        /// Maximum length of the path being displayed next to the file selection button.
        /// </summary>
        private readonly int PATH_DISPLAY_MAX_LENGTH;

        // Data members:
        /// <summary>
        /// Selector for which file to hash.
        /// </summary>
        private OpenFileDialog open_file_dialog;

        /// <summary>
        /// The algorithm object being used to hash files.
        /// </summary>
        private HashAlgorithm algorithm;

        /// <summary>
        /// Path to currently selected file.
        /// </summary>
        private string file_path;
        #endregion


        #region Constructors:
        /// <summary>
        /// Constructor that initializes all components to defaults.
        /// </summary>
        public Hash_Checker_Form()
        {
            InitializeComponent();

            // initialize readonlys
            PATH_DISPLAY_MAX_LENGTH = 50;

            // initialize members
            algorithm = null;
			file_path = null;
            open_file_dialog = new OpenFileDialog();
        } // end Constructor 
        #endregion


        #region Event Handlers:
        /// <summary>
        /// On-click event handler for select file button. Opens a file-picker dialog
        /// and then stores that file name in <see cref="file_path"/>. Also displays
        /// the first <see cref="PATH_DISPLAY_MAX_LENGTH"/> characters in the 
        /// <see cref="file_name_lbl"/>.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void Select_file_click(object sender, EventArgs e)
        {
            var result = open_file_dialog.ShowDialog();
		
            // ensure file dialog box closed correctly
            if(result == DialogResult.OK)
            {
                // build path for display
                var path = new StringBuilder();
                path.Append("Path: ");

                // store path internally for calculating hashes later
                file_path = open_file_dialog.FileName;

                // avoid displaying long paths that run off-screen
                if(file_path.Length <= PATH_DISPLAY_MAX_LENGTH)
                {
                    path.Append(file_path);
                } // end if
                else
                {
                    path.Append(file_path.Substring(0, PATH_DISPLAY_MAX_LENGTH));
                    path.Append("...");
                } // end else

                // display path to user
                file_name_lbl.Text = path.ToString();
            } // end if
        } // end method select_file_click


        /// <summary>
        /// Calculates the currently selected hash (in <see cref="hash_dropdown"/>)
        /// for the selected file (in <see cref="file_path"/>) and displays the hash
        /// string in <see cref="hash_textbox"/> if both inputs were valid.
        /// If <see cref="verify_hash_checkbox"/> is checked, it also verifies the 
        /// calculated hash for correctness using <see cref="Verify_hash_values(string)"/>.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void Calculate_hash_Click(object sender, EventArgs e)
        {
            if (file_path == null)
            {
                string message = "You did not select a file yet!";
                string caption = "Error: No File Selected";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult res;

                res = MessageBox.Show(message, caption, button);
            } // end if
			else
			{
				string hash = Hash_file(file_path);

				if(hash != null)
				{
					hash_textbox.Text = hash;
					hash_textbox.Visible = true;

					if (verify_hash_checkbox.Checked)
					{
						Verify_hash_values(hash);
					} // end if verify_hash_checkbox.Checked
				} // end if hash != null
                else
                {
                    hash_textbox.Text = string.Empty;
                    hash_textbox.Visible = false;
                    verification_lbl.Visible = false;
                } // end else hash == null
			} // end else	
        } // end method calculate_hash_Click


        /// <summary>
        /// On-changed event handler for <see cref="verify_hash_checkbox"/> checkbox.
        /// Toggles the <see cref="expected_hash"/> textbox, <see cref="expected_lbl"/>
        /// label, and <see cref="verification_lbl"/>. If the checkbox is checked, these
        /// are displayed, otherwise they are hidden. The value of <see cref="verification_lbl"/>
        /// reset to <see cref="string.Empty"/> with each call.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void Verify_checkbox_changed(object sender, EventArgs e)
        {
            expected_lbl.Visible = verify_hash_checkbox.Checked;
            expected_hash.Visible = verify_hash_checkbox.Checked;
            verification_lbl.Visible = verify_hash_checkbox.Checked;
            verification_lbl.Text = string.Empty;
        } // end method verify_checkbox_changed


        /// <summary>
        /// On-changed event handler for <see cref="hash_dropdown"/> dropdown list.
        /// Disposes of the old <see cref="algorithm"/> object (if applicable) and
        /// instantiates a new one based on the user's selection. 
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void Hash_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = hash_dropdown.SelectedItem as string;

            // properly dispose of old algorithm object if applicable
            if (algorithm != null)
            {
                algorithm.Dispose();
                algorithm = null;
            } // end if

            // instantiate appropriate algorithm object
            switch (selected)
            {
                case "MD5":
                    algorithm = MD5.Create();
                    break;
                case "SHA1":
                    algorithm = SHA1.Create();
                    break;
                case "SHA256":
                    algorithm = SHA256.Create();
                    break;
                case "SHA512":
                    algorithm = SHA512.Create();
                    break;
                default:
                    // algorithm is already null from if statement above
                    break;
            } // end switch
        } // end method hash_dropdown_SelectedIndexChanged
        #endregion


        #region Utility Functions:
        /// <summary>
        /// compares the calculated <paramref name="hash"/> against a string entered by 
        /// the user into <see cref="expected_hash"/>. If the hashes match, a green message
        /// is displayed in <see cref="verification_lbl"/>, otherwise a red message is 
        /// displayed. 
        /// </summary>
        /// <param name="hash"></param>
        private void Verify_hash_values(string hash)
        {
            if(hash == expected_hash.Text.ToLowerInvariant())
            {
                verification_lbl.Text = "The expected hash is correct!";
                verification_lbl.Visible = true;
                verification_lbl.BackColor = Color.Green;
            } // end if
            else
            {
                verification_lbl.Text = "The expected hash is NOT correct!";
                verification_lbl.Visible = true;
                verification_lbl.BackColor = Color.Red;
            } // end else
        } // end method verify_hash_values


        /// <summary>
        /// Calculates the hash for a given file located at <paramref name="file_path"/>
        /// and returns the hash as a hexadecimal string with any separators removed.
        /// </summary>
        /// <param name="file_path">The path to the file to check, or null.</param>
        /// <returns>
        /// A hexadecimal string if <paramref name="file_path"/> was a valid file path
        /// and a valid <see cref="HashAlgorithm"/> object was available 
        /// (in <see cref="algorithm"/> on method invocation, otherwise null.
        /// </returns>
        /// <remarks>
        /// The exact hashing strategy to use is determined by the value of
        /// <see cref="algorithm"/>.
        /// </remarks>
        private string Hash_file(string file_path)
        {
            string result = null;

            if(algorithm == null)
            {
                string message = "You did not select a hashing algorithm!";
                string caption = "Error: No Algorithm Selected";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult res = MessageBox.Show(message, caption, button);
            } // end if
            else
            {
                using (var stream = File.OpenRead(file_path))
                {
                    // hash the file and convert the hash to lowercase string without dashes for nice display
                    result = BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                } // end using
            } // end else
            
            return result;
        } // end method hash_file
        #endregion
    } // end class Form1
} // end namespace MD_5_checker
