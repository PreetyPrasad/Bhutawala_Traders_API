namespace Bhutawala_Traders_API.Repositories
{
    public class htmlFormater
    {
        public string createAccountFormate(string FullName, string UserName, string Password)
        {
            var formate = @"<!DOCTYPE html>
                                <html lang='en'>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>Login Details</title>
                                    <style>
                                        body {
                                            font-family: Arial, sans-serif;
                                            background-color: #f4f4f4;
                                            margin: 0;
                                            padding: 0;
                                        }
                                        .email-container {
                                            max-width: 500px;
                                            margin: 20px auto;
                                            background: #ffffff;
                                            padding: 20px;
                                            border-radius: 10px;
                                            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
                                        }
                                        .header {
                                            text-align: center;
                                            color: #007bff;
                                            font-size: 22px;
                                            font-weight: bold;
                                            margin-bottom: 20px;
                                        }
                                        .content {
                                            font-size: 16px;
                                            color: #333;
                                            line-height: 1.6;
                                        }
                                        .login-details {
                                            background: #f9f9f9;
                                            padding: 15px;
                                            border-radius: 8px;
                                            margin: 15px 0;
                                        }
                                        .login-details p {
                                            margin: 5px 0;
                                            font-weight: bold;
                                        }
                                        .login-btn {
                                            display: block;
                                            text-align: center;
                                            background: #007bff;
                                            color: #ffffff;
                                            text-decoration: none;
                                            padding: 12px;
                                            border-radius: 5px;
                                            margin-top: 15px;
                                            font-size: 16px;
                                            font-weight: bold;
                                        }
                                        .login-btn:hover {
                                            background: #0056b3;
                                        }
                                        .footer {
                                            font-size: 14px;
                                            text-align: center;
                                            color: #666;
                                            margin-top: 20px;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class='email-container'>
                                        <div class='header'>
                                            Your Login Credentials
                                        </div>
                                        <div class='content'>
                                            <p>Hello <b>" + FullName + @"</b>,</p>
                                            <p>Your account has been created successfully. Below are your login details:</p>
            
                                            <div class='login-details'>
                                                <p>👤 <b>Username:</b> " + UserName + @"</p>
                                                <p>🔑 <b>Password:</b> " + Password + @"</p>
                                            </div>

                                            <p>Click the button below to log in to your account:</p>
            
                                            <a href='https://yourwebsite.com/login' class='login-btn'>Login to Your Account</a>

                                            <p style='color: red; font-weight: bold;'>⚠️ We recommend changing your password after your first login.</p>
                                        </div>

                                        <div class='footer'>
                                            <p>Need help? Contact us at <a href='mailto:support@yourwebsite.com'>support@yourwebsite.com</a></p>
                                            <p>© 2025 Your Company. All rights reserved.</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";
            return formate;
        }


        public string forgotPasswordFormate(string FullName, string UserName, string Password)
        {
            var formate = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                <title>Account Recovery</title>
                                <style>
                                    body {
                                        font-family: Arial, sans-serif;
                                        background-color: #f4f4f4;
                                        margin: 0;
                                        padding: 0;
                                    }
                                    .email-container {
                                        max-width: 500px;
                                        margin: 20px auto;
                                        background: #ffffff;
                                        padding: 20px;
                                        border-radius: 10px;
                                        box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
                                    }
                                    .header {
                                        text-align: center;
                                        color: #d9534f;
                                        font-size: 22px;
                                        font-weight: bold;
                                        margin-bottom: 20px;
                                    }
                                    .content {
                                        font-size: 16px;
                                        color: #333;
                                        line-height: 1.6;
                                    }
                                    .login-box {
                                        background: #f9f9f9;
                                        padding: 15px;
                                        border-radius: 8px;
                                        margin: 15px 0;
                                    }
                                    .login-btn {
                                        display: block;
                                        text-align: center;
                                        background: #d9534f;
                                        color: #ffffff;
                                        text-decoration: none;
                                        padding: 12px;
                                        border-radius: 5px;
                                        margin-top: 15px;
                                        font-size: 16px;
                                        font-weight: bold;
                                    }
                                    .login-btn:hover {
                                        background: #c9302c;
                                    }
                                    .footer {
                                        font-size: 14px;
                                        text-align: center;
                                        color: #666;
                                        margin-top: 20px;
                                    }
                                </style>
                            </head>
                            <body>
                                <div class='email-container'>
                                    <div class='header'>
                                        Account Recovery
                                    </div>
                                    <div class='content'>
                                        <p>Hello <b>" + FullName + @"</b>,</p>
                                        <p>Here are your account details. Please use the credentials below to log in and <b>change your password immediately.</b></p>
                                        <div class='login-box'>
                                            <p><b>Username:</b> " + UserName + @"</p>
                                            <p><b>Temporary Password:</b> " + Password + @"</p>
                                        </div>
                                        <a href='https://yourwebsite.com/login' class='login-btn'>Login Now</a>

                                        <p style='color: red; font-weight: bold;'>⚠️ For security reasons, change your password after logging in.</p>
                                    </div>
                                    <div class='footer'>
                                        <p>Need help? Contact us at <a href='mailto:support@yourwebsite.com'>support@yourwebsite.com</a></p>
                                        <p>© 2025 Your Company. All rights reserved.</p>
                                    </div>
                                </div>
                            </body>
                            </html>";
            return formate;
        }

    }
}
