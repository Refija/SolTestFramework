using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolentroFrame;
using SolentroFrame.Pages;

namespace SolentroTest.FullScopeTests
{
    [TestClass]
    public class FullScopeTests : TestBase
    {
        /// <summary>
        /// http://jira.semsudin.com/browse/S20-50
        /// </summary>
        [TestMethod]
        public void S20_50_FindBookSizesTest()
        {
            Base.OpenSolentro(Domains.Random);
            Homepage.VerifyBookSizes();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-220
        /// </summary>
        [TestMethod]
        public void S20_220_FindBookPagesTest()
        {
            Base.OpenSolentro(Domains.Random);
            Homepage.VerifyBookPages();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-221
        /// </summary>
        [TestMethod]
        public void S20_221_FindBookImagesTest()
        {
            Base.OpenSolentro(Domains.Random);
            Homepage.VerifyBookImages();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-55
        /// </summary>
        [TestMethod]
        public void S20_55_CreateXlBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Xl);
            ProductionPage.CreateBook(SizesOfBook.Xl);
            ProductionPage.VerifyCreatedBook();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-56
        /// </summary>
        [TestMethod]
        public void S20_56_CreateMaxiBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Maxi);
            ProductionPage.CreateBook(SizesOfBook.Maxi);
            ProductionPage.VerifyCreatedBook();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-57
        /// </summary>
        [TestMethod]
        public void S20_57_CreateMaxiPanoramaBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.MaxiPanorama);
            ProductionPage.CreateBook(SizesOfBook.MaxiPanorama);
            ProductionPage.VerifyCreatedBook();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-58
        /// </summary>
        [TestMethod]
        public void S20_58_CreateClassicBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Classic);
            ProductionPage.CreateBook(SizesOfBook.Classic);
            ProductionPage.VerifyCreatedBook();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-59
        /// </summary>
        [TestMethod]
        public void S20_59_CreateSquareBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Square);
            ProductionPage.CreateBook(SizesOfBook.Square);
            ProductionPage.VerifyCreatedBook();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-60
        /// </summary>
        [TestMethod]
        public void S20_60_CreatePanoramaBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Panorama);
            ProductionPage.CreateBook(SizesOfBook.Panorama);
            ProductionPage.VerifyCreatedBook();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-64
        /// </summary>
        [TestMethod]
        public void S20_64_UsingTemplatesOnXlBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Xl);
            ProductionPage.CreateBook(SizesOfBook.Xl);
            ProductionPage.ApplyTemplates();
            ProductionPage.VerifyAppliedTemplates();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-65
        /// </summary>
        [TestMethod]
        public void S20_65_UsingTemplatesOnMaxiBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Maxi);
            ProductionPage.CreateBook(SizesOfBook.Maxi);
            ProductionPage.ApplyTemplates();
            ProductionPage.VerifyAppliedTemplates();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-66
        /// </summary>
        [TestMethod]
        public void S20_66_UsingTemplatesOnMaxiPanoramaBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.MaxiPanorama);
            ProductionPage.CreateBook(SizesOfBook.MaxiPanorama);
            ProductionPage.ApplyTemplates();
            ProductionPage.VerifyAppliedTemplates();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-67
        /// </summary>
        [TestMethod]
        public void S20_67_UsingTemplatesOnClassicBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Classic);
            ProductionPage.CreateBook(SizesOfBook.Classic);
            ProductionPage.ApplyTemplates();
            ProductionPage.VerifyAppliedTemplates();

        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-68
        /// </summary>
        [TestMethod]
        public void S20_68_UsingTemplatesOnSquareBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Square);
            ProductionPage.CreateBook(SizesOfBook.Square);
            ProductionPage.ApplyTemplates();
            ProductionPage.VerifyAppliedTemplates();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-69
        /// </summary>
        [TestMethod]
        public void S20_69_UsingTemplatesOnPanoramaBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Panorama);
            ProductionPage.CreateBook(SizesOfBook.Panorama);
            ProductionPage.ApplyTemplates();
            ProductionPage.VerifyAppliedTemplates();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-173
        /// </summary>
        [TestMethod]
        public void S20_173_DeleteAccountTest()
        {
            Base.OpenSolentro();
            Homepage.RegistrateSolentro();
            ProductionPage.VerifyRegistration();
            ProductionPage.CreateBook(SizesOfBook.Random, TypeOfUser.JustRegistered);
            ProductionPage.DeleteAccount();
            Homepage.VerifyAccountDeletion();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-164
        /// </summary>
        [TestMethod]
        public void S20_164_DeleteProjectTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.DeleteProject();
            ProductionPage.VerifyDeleteProject();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-71
        /// </summary>
        [TestMethod]
        public void S20_71_SwitchTypesOnMaxiBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Maxi);
            ProductionPage.SwitchBookTypes();
            ProductionPage.VerifySwitchBookTypes();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-72
        /// </summary>
        [TestMethod]
        public void S20_72_SwitchTypesOnMaxiPanoramaBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.MaxiPanorama);
            ProductionPage.SwitchBookTypes();
            ProductionPage.VerifySwitchBookTypes();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-73
        /// </summary>
        [TestMethod]
        public void S20_73_SwitchTypesOnClassicBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Classic);
            ProductionPage.SwitchBookTypes();
            ProductionPage.VerifySwitchBookTypes();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-74
        /// </summary>
        [TestMethod]
        public void S20_74_SwitchTypesOnSquareBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Square);
            ProductionPage.SwitchBookTypes();
            ProductionPage.VerifySwitchBookTypes();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-75
        /// </summary>
        [TestMethod]
        public void S20_75_SwitchTypesOnPanoramaBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Panorama);
            ProductionPage.SwitchBookTypes();
            ProductionPage.VerifySwitchBookTypes();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-88
        /// </summary>
        [TestMethod]
        public void S20_88_ChangeDesignTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.ChangeBookDesign();
            ProductionPage.VerifyDesignIsChanged();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-78
        /// </summary>
        [TestMethod]
        public void S20_78_DeleteImagesTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.UploadPhotos();
            ProductionPage.DeleteImages();
            ProductionPage.VerifyDeleteImages();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-79
        /// </summary>
        [TestMethod]
        public void S20_79_UploadMoreThanHundredImagesTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.VerifyCannotUpload101Images();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-80
        /// </summary>
        [TestMethod]
        public void S20_80_PlaceImageOnImageTemplateTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Random);
            ProductionPage.PlaceImageOnField(TemplatesType.WithImageField);
            ProductionPage.VerifyImagePlacedOnTemplate();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-81
        /// </summary>
        [TestMethod]
        public void S20_81_PlaceImageOnTextTemplateTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Random);
            ProductionPage.PlaceImageOnField(TemplatesType.WithTextField);
            ProductionPage.VerifyImagePlacedOnTemplate(false);
        }
        
        /// <summary>
        /// http://jira.semsudin.com/browse/S20-90
        /// </summary>
        [TestMethod]
        public void S20_90_AddSpineTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.AddSpine();
            ProductionPage.VerifyAddSpine();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-77
        /// </summary>
        [TestMethod]
        public void S20_77_VerifyImagesFormatTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.VerifyInvalidImageFormatCannotBeUploaded();
        }
        
        /// <summary>
        /// http://jira.semsudin.com/browse/S20-70
        /// </summary>
        [TestMethod]
        public void S20_70_FinalPageNotEditableTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.VerifyFinalPageNotEditable();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-95
        /// </summary>
        [TestMethod]
        public void S20_95_UserHavingMultipleBooksTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.VerifyHavingMultipleBooks();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-53
        /// </summary>
        [TestMethod]
        public void S20_53_UnableToRegisterTest()
        {
            Base.OpenSolentro();
            Homepage.VerifyUnableToRegisterWithWrongOrInvalidEmail();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-62
        /// </summary>
        [TestMethod]
        public void S20_62_LoginEmailNegativeCaseTest()
        {
            Base.OpenSolentro();
            Homepage.TryLoginWithWrongOrInvalidEmail();
            Homepage.VerifyUserNotLoggedIn();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-63
        /// </summary>
        [TestMethod]
        public void S20_63_LoginPasswordNegativeCaseTest()
        {
            Base.OpenSolentro();
            Homepage.TryLoginWithIncorrectPassword();
            Homepage.VerifyUserNotLoggedIn();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-94
        /// </summary>
        [TestMethod]
        public void S20_94_SpreadImageTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.VerifySpreadImageOnTwoPages();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-94
        /// </summary>
        [TestMethod]
        public void S20_93_DesignSinglePageTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.VerifyDesignSinglePageWithPhoto();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-82
        /// </summary>
        [TestMethod]
        public void S20_82_CropImageTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CropImages();
            ProductionPage.VerifyImageIsCropped();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-86 
        /// </summary>
        [TestMethod]
        public void S20_86_AddPagesLimitTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.SwitchBookTypes();
            ProductionPage.AddOrRemovePages(false, true);
            ProductionPage.VerifyThatPagesAreAddedOrRemovedInOrOutOfScope();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-87 
        /// </summary>
        [TestMethod]
        public void S20_87_RemovePagesLimitTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.SwitchBookTypes();
            ProductionPage.AddOrRemovePages(false, false);
            ProductionPage.VerifyThatPagesAreAddedOrRemovedInOrOutOfScope();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-92
        /// </summary>
        [TestMethod]
        public void S20_92_CustomizeBackgroundTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.VerifyCustomizeBackground();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-83
        /// </summary>
        [TestMethod]
        public void S20_83_UnableToCropLowResolutionImageTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.VerifyUserCannotCropLowResolutionImage();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-96
        /// http://jira.semsudin.com/browse/S20-97
        /// http://jira.semsudin.com/browse/S20-98
        /// </summary>
        [TestMethod]
        public void S20_96_InviteOthersTest()
        {
            Base.OpenSolentro();
            Homepage.RegistrateSolentro();
            ProductionPage.VerifyRegistration();
            ProductionPage.CreateBook(SizesOfBook.Random, TypeOfUser.JustRegistered);
            ProductionPage.InviteOthers();
            ContributePage.ContributeKey();
            ContributePage.Contribute();
            Homepage.LoginSolentro(Emails.GeneratedEmail);
            ProductionPage.VerifyContributedImageIsUploaded();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-89
        /// </summary>
        [TestMethod]
        public void S20_89_CustomTemplatesTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.VerifyUserCanCreateCustomTemplates();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-15
        /// </summary>
        [TestMethod]
        public void S20_15_VerifyUserCanFindBookBindingsTest()
        {
            Base.OpenSolentro();
            Homepage.VerifyBookBindingsDisplayed();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-91
        /// </summary>
        [TestMethod]
        public void S20_91_VerifyThatUserCanPreviewBookTest()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro();
            ProductionPage.CreateBook();
            ProductionPage.VerifyPreviewBook();
        }
        
        /// <summary>
        /// http://jira.semsudin.com/browse/S20-232
        /// </summary>
        [TestMethod]
        public void S20_232_VerifyThatUserCanPreviewFAQTest()
        {
            Base.OpenSolentro(Domains.Random);
            Homepage.VerifyFAQ();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-51
        /// </summary>
        [TestMethod]
        public void S20_51_VerifyBookPricesTest()
        {
            Homepage.VerifyBookPrices();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-235
        /// </summary>
        [TestMethod]
        public void S20_235_VerifyThatUserCanPreviewTaCTest()
        {
            Base.OpenSolentro(Domains.Random);
            Homepage.VerifyTermsAndConditions();
        }

        /// <summary>
        /// http://jira.semsudin.com/browse/S20-252
        /// </summary>
        [TestMethod]
        public void S20_252_VerifyThatUserCanUseShowAllImagesButon()
        {
            Base.OpenSolentro();
            Homepage.LoginSolentro(Emails.Random);
            ProductionPage.UploadPhotos();
            ProductionPage.VerifyUsageOfShowAllImagesButton();
        }
    }
}
