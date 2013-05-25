using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAMP_Forms.Forms;
using DAMP_Forms.Business;

namespace DAMP_Forms
{
    public partial class Form1 : Form
    {
        bLogin objbLogin = new bLogin();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetData();
            if (objbLogin.LoginAuthentication(txtPassword.Text.Trim()))
            {
                MainFrm frm1 = new MainFrm();
                this.Hide();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Login Fail !!!");
            }
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Encrypts a given password and returns the encrypted data
        ///// as a base64 string.
        ///// </summary>
        ///// <param name="plainText">An unencrypted string that needs
        ///// to be secured.</param>
        ///// <returns>A base64 encoded string that represents the encrypted
        ///// binary data.
        ///// </returns>
        ///// <remarks>This solution is not really secure as we are
        ///// keeping strings in memory. If runtime protection is essential,
        ///// <see cref="SecureString"/> should be used.</remarks>
        ///// <exception cref="ArgumentNullException">If <paramref name="plainText"/>
        ///// is a null reference.</exception>
        //public string Encrypt(string plainText)
        //{
        //    if (plainText == null) throw new ArgumentNullException("plainText");

        //    //encrypt data
        //    var data = Encoding.Unicode.GetBytes(plainText);
        //    byte[] encrypted = ProtectedData.Protect(data, null, Scope);

        //    //return as base64 string
        //    return Convert.ToBase64String(encrypted);
        //}

        ///// <summary>
        ///// Decrypts a given string.
        ///// </summary>
        ///// <param name="cipher">A base64 encoded string that was created
        ///// through the <see cref="Encrypt(string)"/> or
        ///// <see cref="Encrypt(SecureString)"/> extension methods.</param>
        ///// <returns>The decrypted string.</returns>
        ///// <remarks>Keep in mind that the decrypted string remains in memory
        ///// and makes your application vulnerable per se. If runtime protection
        ///// is essential, <see cref="SecureString"/> should be used.</remarks>
        ///// <exception cref="ArgumentNullException">If <paramref name="cipher"/>
        ///// is a null reference.</exception>
        //public string Decrypt(string cipher)
        //{
        //    if (cipher == null) throw new ArgumentNullException("cipher");

        //    //parse base64 string
        //    byte[] data = Convert.FromBase64String(cipher);

        //    //decrypt data
        //    byte[] decrypted = ProtectedData.Unprotect(data, null, Scope);
        //    return Encoding.Unicode.GetString(decrypted);
        //}

        private void SetData()
        {
            try
            {
                objbLogin.user_id = txtUserID.Text.Trim();
                objbLogin.password = txtPassword.Text.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
