using Bhutawala_Traders_API.Models;

namespace Bhutawala_Traders_API.Repositories
{
    public class htmlFormater
    {
        //public string GenerateInvoiceText(InvoiceMaster invoice)
        //{
        //    string invoiceText = $"📜 *Invoice Receipt*\n\n" +
        //                         $"🧾 *Invoice No:* {invoice.InvoiceNo}\n" +
        //                         $"📅 *Date:* {invoice.InvoiceDate:dd-MM-yyyy}\n" +
        //                         $"👤 *Customer:* {invoice.CustomerName}\n" +
        //                         $"📞 *Contact:* {invoice.ContactNo}\n" +
        //                         $"🆔 *GSTIN:* {invoice.GSTIN}\n" +
        //                         $"💰 *Total Amount:* ₹{invoice.Total}\n" +
        //                         $"✅ *Paid:* ₹{invoice.installments.Sum(i => i.Amount)}\n" +
        //                         $"❌ *Due:* ₹{(invoice.Total - invoice.installments.Sum(i => i.Amount))}\n\n" +
        //                         $"🛒 *Purchased Items:*\n";

        //    foreach (var item in invoice.InvoiceDetails)
        //    {
        //        invoiceText += $"🔹 {item.MaterialName} - {item.Qty} x ₹{item.Rate} = ₹{item.Total}\n";
        //    }

        //    invoiceText += "\n💳 *Payments Received:*\n";

        //    foreach (var payment in invoice.installments)
        //    {
        //        invoiceText += $"📌 {payment.Paymentmode} | Ref: {payment.RefNo} | ₹{payment.Amount}\n";
        //    }

        //    invoiceText += "\n🙏 *Thank you for your business!*\n";

        //    return invoiceText;
        //}

        //public string GetWhatsAppMessageUrl(InvoiceMaster invoice)
        //{
        //    string phoneNumber = invoice.ContactNo.Replace(" ", "").Replace("-", "").Replace("+", ""); // Clean phone number
        //    string message = Uri.EscapeDataString(GenerateInvoiceText(invoice)); // Encode message for URL
        //    return $"https://wa.me/{phoneNumber}?text={message}";
        //}

        public string GenerateInvoiceHtml(InvoiceMaster invoice)
        {
            string invoiceHtml = $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; }}
                    .invoice-container {{ width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; }}
                    .header {{ text-align: center; font-size: 20px; font-weight: bold; }}
                    .details-table, .items-table {{ width: 100%; border-collapse: collapse; margin-top: 10px; }}
                    .details-table td, .items-table td, .items-table th {{ border: 1px solid #ddd; padding: 8px; }}
                    .total-section {{ font-size: 18px; font-weight: bold; margin-top: 20px; }}
                </style>
            </head>
            <body>
                <div class='invoice-container'>
                    <div class='header'>Invoice Receipt</div>
                    <table class='details-table'>
                        <tr><td><b>Invoice No:</b></td><td>{invoice.InvoiceNo}</td></tr>
                        <tr><td><b>Date:</b></td><td>{invoice.InvoiceDate.ToString("dd-MM-yyyy")}</td></tr>
                        <tr><td><b>Customer:</b></td><td>{invoice.CustomerName}</td></tr>
                        <tr><td><b>Contact:</b></td><td>{invoice.ContactNo}</td></tr>
                        <tr><td><b>GSTIN:</b></td><td>{invoice.GSTIN}</td></tr>
                        <tr><td><b>GST Type:</b></td><td>{invoice.GST_TYPE}</td></tr>
                        <tr><td><b>Total Gross:</b></td><td>₹{invoice.TotalGross}</td></tr>
                        <tr><td><b>GST:</b></td><td>₹{invoice.GST}</td></tr>
                        <tr><td><b>Total:</b></td><td>₹{invoice.Total}</td></tr>
                    </table>
            
                    <h3>Purchase Details</h3>
                    <table class='items-table'>
                        <tr><th>Material</th><th>Qty</th><th>Rate</th><th>GST</th><th>Total</th></tr>";

                    foreach (var item in invoice.InvoiceDetails)
                    {
                        invoiceHtml += $@"
                    <tr>
                        <td>{item.MaterialName}</td>
                        <td>{item.Qty}</td>
                        <td>₹{item.Rate}</td>
                        <td>₹{item.GSTAmount}</td>
                        <td>₹{item.Total}</td>
                    </tr>";
                    }

                    invoiceHtml += $@"
                    </table>

                    <h3>Payments</h3>
                    <table class='items-table'>
                        <tr><th>Payment Mode</th><th>Reference No</th><th>Amount</th></tr>";

                    foreach (var payment in invoice.installments)
                    {
                        invoiceHtml += $@"
                    <tr>
                        <td>{payment.Paymentmode}</td>
                        <td>{payment.RefNo}</td>
                        <td>₹{payment.Amount}</td>
                    </tr>";
                    }

                    invoiceHtml += $@"
                    </table>

                    <div class='total-section'>
                        <p><b>Total Paid:</b> ₹{invoice.installments.Sum(i => i.Amount)}</p>
                        <p><b>Dues:</b> ₹{invoice.Total - invoice.installments.Sum(i => i.Amount)}</p>
                    </div>
                </div>
            </body>
            </html>";

            return invoiceHtml;
        }


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
                                            <p>© 2025 Bhutawala Traders. All rights reserved.</p>
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
