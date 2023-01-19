# Umbraco Contact Form
Contact form for sending an email using Umbraco CMS and the MVC design pattern

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Blazor](https://img.shields.io/badge/blazor-%235C2D91.svg?style=for-the-badge&logo=blazor&logoColor=white)
![HTML](https://img.shields.io/badge/html-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/css-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)

![Home](McLarenUmbraco/documentation/images/Home.PNG)

## Contact Form

![Contact](McLarenUmbraco/documentation/images/Contact.PNG)

### MVC
Model: [/Models/EmailModel.cs](https://github.com/DanielPitfield/Umbraco_Dev_Test/blob/master/McLarenUmbraco/Models/EmailModel.cs)

View (Form): [/Views/Partials/Forms/Email/Email.cshtml](https://github.com/DanielPitfield/Umbraco_Dev_Test/blob/master/McLarenUmbraco/Views/Partials/Forms/Email/Email.cshtml)

View (Page): [/Views/Contact.cshtml](https://github.com/DanielPitfield/Umbraco_Dev_Test/blob/master/McLarenUmbraco/Views/Contact.cshtml)

Controller: [/Controllers/EmailController.cs](https://github.com/DanielPitfield/Umbraco_Dev_Test/blob/master/McLarenUmbraco/Controllers/EmailController.cs)

### Known Issues
A newly created Gmail account is used as authentication to the Gmail SMTP server. The authentication details (i.e login details for that account) are included in version control. Better practice would be to obtain OAuth 2.0 credentials for the solution and use access tokens.

A maximum length for the input values is not enforced (limited testing shows this is particularly problematic with a long input value for the 'Name' field, with the email either not being sent or taking considerable time to reach the recipient).
