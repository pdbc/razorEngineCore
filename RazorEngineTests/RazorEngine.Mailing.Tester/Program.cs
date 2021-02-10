using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using RazorEngine.Mailing.Library;
using RazorEngine.Mailing.Library.Models;
using RazorEngine.Mailing.Library.Templates.BaseTemplate;

namespace RazorEngine.Mailing.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Razor Engine Mailing Tester");
            var mailerService = new MailerService();

            //MigrationAuditRecordTests(mailerService);
            //PasswordChangedAuditRecordTests(mailerService);
            //PersonalProfileMergedAuditRecordTests(mailerService);
            //ProfileDateOfBirthCorrectedAuditRecordTests(mailerService);
            //RegistrationAuditRecordTests(mailerService);


            //VerifyAccountForRecoveryTests(mailerService);
            //VerifyAccountForRegistrationTests(mailerService);

            InvitationTests(mailerService);
            InvitationSingleApplicationTests(mailerService);
            InvitationUnlinkedEmployeeProfile(mailerService);

            Console.WriteLine("All completed!");
        }

        private static void InvitationTests(MailerService mailerService)
        {
            //var viewModel = CreateInvitationViewModel("EN");
            //mailerService.DropMail(viewModel);

            RunInAllLanguages(l =>
            {
                var viewModel = CreateInvitationViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }
        private static void InvitationSingleApplicationTests(MailerService mailerService)
        {
            //var viewModel = CreateInvitationViewModel("EN");
            //mailerService.DropMail(viewModel);

            RunInAllLanguages(l =>
            {
                var viewModel = CreateInvitationViewModelSingleApplication(l);
                viewModel.Applications = new List<string>() {"Single Application"};
                mailerService.DropMail(viewModel);
            });
        }

        private static void InvitationUnlinkedEmployeeProfile(MailerService mailerService)
        {
            //var viewModel = CreateInvitationViewModel("EN");
            //mailerService.DropMail(viewModel);

            RunInAllLanguages(l =>
            {
                var viewModel = CreateInvitationViewModelUnlinkedEmployeeProfile(l);
                viewModel.Applications = new List<string>() { "Single Application" };
                mailerService.DropMail(viewModel);
            });
        }
        private static void MigrationAuditRecordTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreateMigrationAuditRecordViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }

        private static void PasswordChangedAuditRecordTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreatePasswordChangeAuditRecordViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }

        private static void PersonalProfileMergedAuditRecordTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreatePersonalProfileMergedAuditRecordViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }
        private static void ProfileDateOfBirthCorrectedAuditRecordTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreateProfileDateOfBirthCorrectedAuditRecordViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }
        private static void RegistrationAuditRecordTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreateRegistrationAuditRecordViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }

        private static void VerifyAccountForRecoveryTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreateVerifyAccountForRecoveryViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }

        private static void VerifyAccountForRegistrationTests(MailerService mailerService)
        {
            RunInAllLanguages(l =>
            {
                var viewModel = CreateVerifyAccountForRegistrationViewModel(l);
                mailerService.DropMail(viewModel);
            });
        }


        private static void RunInAllLanguages(Action<String> action)
        {
            var languages = new List<String> { "NL", "FR", "EN", "DE", "ES" };
            var numberOfRuns = 3;

            for (int i = 0; i < numberOfRuns; i++)
            {
                languages.ForEach(l =>
                {
                    Console.WriteLine($"Creating mail template service in language ({l}) for run ({i + 1}) ");
                    PerformTimedAction(() =>
                    {
                        action(l);
                    });
                });
            }
        }

        private static void PerformTimedAction(Action action)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            action();

            stopWatch.Stop();
            Console.WriteLine($"Elapsed: {stopWatch.ElapsedMilliseconds}");
        }

        private static InvitationViewModel CreateInvitationViewModelSingleApplication(string templateLanguage)
        {
            var model = new InvitationViewModel()
            {
                MailInfo = CreatMailInfo("InvitationForSingleApplicationPortal", templateLanguage),
                ApplicationScope = "ABC",

                AccountOfficialName = "Official account name",
                Applications = new List<string>() { "Application Single"},
                DateOfBirth = new DateTime(2000, 02, 01),
                Url = "https://invitation.url.com",


            };

            model.MailInfo.ApplicationScope = "ApplicationScope !!";

            return model;
        }

        private static InvitationViewModel CreateInvitationViewModelUnlinkedEmployeeProfile(string templateLanguage)
        {
            var model = new InvitationViewModel()
            {
                MailInfo = CreatMailInfo("InvitationForAutoUnlinkedEmloyeeProfile", templateLanguage),
                ApplicationScope = "ABC",

                AccountOfficialName = "Official account name",
                Applications = new List<string>() {"Application Single"},
                DateOfBirth = new DateTime(2000, 02, 01),
                Url = "https://invitation.url.com",


            };

            model.MailInfo.ApplicationScope = "ApplicationScope !!";

            return model;
        }

        private static InvitationViewModel CreateInvitationViewModel(string templateLanguage)
        {
            var model = new InvitationViewModel()
            {
                MailInfo = CreatMailInfo("Invitation", templateLanguage),
                ApplicationScope = "ABC",

                AccountOfficialName = "Official account name",
                Applications = new List<string>() { "Application1", "Application2"},
                DateOfBirth = new DateTime(2000,02,01),
                Url = "https://invitation.url.com",


            };

            model.MailInfo.ApplicationScope = "ApplicationScope !!";

            return model;
        }

        private static AuditProfileViewModel CreateMigrationAuditRecordViewModel(String templateLanguage)
        {
            var model = CreateAuditProfileViewModel("MigrationAuditRecord", templateLanguage);

            return model;
        }
        private static AuditProfileViewModel CreatePasswordChangeAuditRecordViewModel(String templateLanguage)
        {
            var model = CreateAuditProfileViewModel("PasswordChangedAuditRecord", templateLanguage);

            return model;
        }
        private static AuditProfileMergeViewModel CreatePersonalProfileMergedAuditRecordViewModel(String templateLanguage)
        {
            //var model = CreateAuditProfileViewModel("PersonalProfileMergedAuditRecord", templateLanguage);
            var model = new AuditProfileMergeViewModel()
            {
                MailInfo = CreatMailInfo("PersonalProfileMergedAuditRecord", templateLanguage),
                AuditDescription = "Description AUDIT",
                PortalAuditUrl = "portal audit URL",
                PortalProfileUrl = "portal profile URL",
                DateOfBirth = "01/01/2000",
                Firstname = "Firstname",
                Lastname = "Lastname",
                EmailAddress = "EmailAddress",
                MobileNumber = "MobileNumber",
                MobileNumberPrefix = "Prefix",
                PreviousEmailAddress = "Previoues Email",
                RecoveryEmailAddresses = new List<string>()
                {
                    "Recovery A", "Recovery B"
                }
            };
            return model;
        }
        private static DateOfBirthCorrectedViewModel CreateProfileDateOfBirthCorrectedAuditRecordViewModel(String templateLanguage)
        {
            var model = new DateOfBirthCorrectedViewModel()
            {
                MailInfo = CreatMailInfo("ProfileDateOfBirthCorrectedAuditRecord", templateLanguage),
                AuditDescription = "Description AUDIT",
                NewDateOfBirth = "01/02/0304",
                PortalAuditUrl = "portal audit URL",
                PortalProfileUrl = "portal profile URL",
            };

            return model;
        }
        private static AuditProfileViewModel CreateRegistrationAuditRecordViewModel(String templateLanguage)
        {
            var model = CreateAuditProfileViewModel("RegistrationAuditRecord", templateLanguage);

            return model;
        }
        private static AuditProfileViewModel CreateAuditProfileViewModel(String templateName, string templateLanguage)
        {
            var model = new AuditProfileViewModel()
            {
                MailInfo = CreatMailInfo(templateName, templateLanguage),
                AuditDescription = "Audit description",
                DateOfBirth = "01/01/2000",
                Firstname = "Firstname",
                Lastname = "Lastname",
                EmailAddress = "EmailAddress",
                MobileNumber = "MobileNumber",
                MobileNumberPrefix = "Prefix",
                PortalAuditUrl = "portal audit URL",
                PortalProfileUrl = "portal profile URL",
                RecoveryEmailAddresses = new List<string>()
                {
                    "Recovery A", "Recovery B"
                }
            };
            return model;
        }

        private static VerifyAccountRecoveryViewModel CreateVerifyAccountForRecoveryViewModel(string templateLanguage)
        {
            var model = new VerifyAccountRecoveryViewModel()
            {
                MailInfo = CreatMailInfo("VerifyAccountForRecovery", templateLanguage),
                VerificationCode = "885522"
               
            };
            return model;
        }
        private static VerifyAccountViewModel CreateVerifyAccountForRegistrationViewModel(String templateLanguage)
        {
            var model = new VerifyAccountViewModel()
            {
                MailInfo = CreatMailInfo("VerifyAccountForRegistration", templateLanguage),
                VerificationCode = "445566"

            };
            return model;
        }
        private static MailInfo CreatMailInfo(String templateName, String templateLanguage)
        {
            var model = new MailInfo()
            {
                TemplateName = templateName,
                TemplateLanguageCode = templateLanguage,
                Subject = $"Subject - {templateName}",
                Firstname = "Firstname",
                Lastname = "Lastname",

                ToEmailAddress = "patrick@allors.com",
            };

            return model;
        }
    }



    // Singleton class
}
