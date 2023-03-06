# SMS_MVCDTO

= allow to view product which stock are lower than certain amount // creat a methos that will always check if a stock is lower than certain number 
#view product by categories
#add wallet to track  admin withdrawal and 
# view each attendant history
#purchasing multiple product same time
#allow customer to view list of product below certain price
#specify the attendants for particular transaction
#Admin for different branch

Kindly select one of the following options:
1. View Profile
2. Update profile
3. Register New Admin
4. Change Password
5. Add New Customers
6. View Customers
7. View all Attendants on Shift
8. Add New Attendants
9. View all Attendants
10. Perform inventory operations
11. Recall Order
12. View Order History
    {
        Kindly select one of the following options:
            1. View All Orders
            2. View Orders by date
            3. View Orders by attendant
            0. Go back to previous menu        
    }
0. Exit/ Log out




vLIDte check email
admin should not Change attendant pasw
reorder poin handle excetio pres2
create list of barcodes









#stated



#  Manage Attendant
                        {
                           
                    // Add new Attendant
                   
                    //view for attendant
                  
                    //view all attendant
                   
                    //update attendant profile
                   
                    // reset attendant password
                    
                    // Delete Attendants

                        }


#Manage Products 
                    // Add Product
                    // Modify product
                    // View All products
                    // logout
#Manage Inventory
                    // Restock product.
                    // View all products expected to be Reordered. .
                    // view Product lower than certain number.
     
#Manage Transactions 

#Update detail
#Update password
#Check Wallet Balance
   
#SuperAdmin  SBK951699 123
#Attendant TEN183027  123





            Configuration.Default.ApiKey.Add("api-key", "YOUR API KEY");

            var apiInstance = new TransactionalEmailsApi();
            string SenderName = "John Doe";
            string SenderEmail = "example@example.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = "example1@example1.com";
            string ToName = "John Doe";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            string BccName = "Janice Doe";
            string BccEmail = "example2@example2.com";
            SendSmtpEmailBcc BccData = new SendSmtpEmailBcc(BccEmail, BccName);
            List<SendSmtpEmailBcc> Bcc = new List<SendSmtpEmailBcc>();
            Bcc.Add(BccData);
            string CcName = "John Doe";
            string CcEmail = "example3@example2.com";
            SendSmtpEmailCc CcData = new SendSmtpEmailCc(CcEmail, CcName);
            List<SendSmtpEmailCc> Cc = new List<SendSmtpEmailCc>();
            Cc.Add(CcData);
            string HtmlContent = "<html><body><h1>This is my first transactional email {{params.parameter}}</h1></body></html>";
            string TextContent = null;
            string Subject = "My {{params.subject}}";
            string ReplyToName = "John Doe";
            string ReplyToEmail = "replyto@domain.com";
            SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);
            string AttachmentUrl = null;
            string stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
            byte[] Content = System.Convert.FromBase64String(stringInBase64);
            string AttachmentName = "test.txt";
            SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
            List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
            Attachment.Add(AttachmentContent);
            JObject Headers = new JObject();
            Headers.Add("Some-Custom-Name", "unique-id-1234");
            long? TemplateId = null;
            JObject Params = new JObject();
            Params.Add("parameter", "My param value");
            Params.Add("subject", "New Subject");
            List<string> Tags = new List<string>();
            Tags.Add("mytag");
            SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
            List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
            To1.Add(smtpEmailTo1);
            Dictionary<string, object> _parmas = new Dictionary<string, object>();
            _parmas.Add("params", Params);
            SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
            SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
            List<SendSmtpEmailMessageVersions> messageVersiopns = new List<SendSmtpEmailMessageVersions>();
            messageVersiopns.Add(messageVersion);
            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, Bcc, Cc, HtmlContent, TextContent, Subject, ReplyTo, Attachment, Headers, TemplateId, Params, messageVersiopns, Tags);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                Debug.WriteLine(result.ToJson());
                Console.WriteLine(result.ToJson());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }