using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public InputField loginUsername;
    public InputField loginPassword;
    public Button loginButton;

    public Text loginUsernameValidation;
    public Text loginPasswordValidation;

    private string Username = "";
    private string Password = "";
    private string[] Lines;
    private string DecryptedPassword = "";


    public void Login()
    {
        bool UN = false;
        bool PW = false;

        // Checks if username exists.
        if (Username != "")
        {
            if (System.IO.File.Exists(@"C:\Desktop\MochimojiUsers\" + Username + ".txt"))
            {
                UN = true;
                Lines = new string[0];
                Lines = System.IO.File.ReadAllLines(@"C:\Desktop\MochimojiUsers\" + Username + ".txt");
                loginUsernameValidation.gameObject.SetActive(false);
            }
            else
            {
                loginUsernameValidation.text = "Username does not exist. Please register.";
                loginUsernameValidation.gameObject.SetActive(true);
            }
        }
        else
        {
            loginUsernameValidation.text = "Username field must not be empty.";
            loginUsernameValidation.gameObject.SetActive(true);
        }

        // Checks if password is valid.
        if (Password != "")
        {
            if (System.IO.File.Exists(@"C:\Desktop\MochimojiUsers\" + Username + ".txt"))
            {
                // Encrypt the password.
                int i = 1;
                foreach (char character in Lines[1])
                {
                    i++;
                    char Decrypted = (char)(character / i);
                    DecryptedPassword += Decrypted.ToString();
                }

                // Check if passwords match.
                if (Password == DecryptedPassword)
                {
                    PW = true;
                    loginPasswordValidation.gameObject.SetActive(false);
                }
                else
                {
                    loginPasswordValidation.text = "Password is incorrect.";
                    loginPasswordValidation.gameObject.SetActive(true);
                    DecryptedPassword = "";
                }

            }
        }
        else
        {
            loginPasswordValidation.text = "Password field must not be empty.";
            loginPasswordValidation.gameObject.SetActive(true);
        }

        // If everything is valid.
        if (UN == true && PW == true)
        {
            // Save account info to player preferences.
            PlayerPrefs.SetString("LoggedUser", Username);

            // Load start scene.
            SceneManager.LoadSceneAsync("GameStartScene", LoadSceneMode.Single);
        }
    }

    // Allow user to tab through fields and clicking Enter will submit the form.
    void Update()
    {
        // If user clicks Tab key, it will select next input field.
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (loginUsername.isFocused)
            {
                loginPassword.Select();
            }
            if (loginPassword.isFocused)
            {
                loginButton.Select();
            }
        }

        // If user clicks enter/return key, it will submit the form.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Username != "")
            {
                Login();
            }
        }

        Username = loginUsername.text;
        Password = loginPassword.text;
    }
}
