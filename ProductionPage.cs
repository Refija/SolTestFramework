using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SolentroFrame.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace SolentroFrame.Pages
{
    public class ProductionPage : Base
    {
        #region Web elements and locators
        public static IWebElement OkButton => Browser.FindElement(By.XPath("//*[@class='exitBtn exit-from-messageBox prod_button']")); 
        public static IWebElement XTemplate => Browser.FindElement(By.Id("template_x"));
        public static IWebElement TemplateSaveBtn => Browser.FindElement(By.Id("template_editor_save"));
        public static IWebElement TemplateCloseBtn => Browser.FindElement(By.Id("template_editor_close"));
        public static IList<IWebElement> CheckSavedTempate => Browser.FindElements(By.XPath("//*[@id='user_templates_container']/div"));
        public static IWebElement TEAddText => Browser.FindElement(By.Id("template_editor_add_text"));
        public static IWebElement TEAddImage => Browser.FindElement(By.Id("template_editor_add_image"));
        public static IWebElement UserTemplateBtn => Browser.FindElement(By.Id("user_template_btn"));
        public static IWebElement CustomizeBtn => Browser.FindElement(By.Id("sidebar_tab_user_templates"));
        public static IWebElement LogoutButton => Browser.FindElement(By.Id("sidebar_btn_logout"));
        public static IWebElement NewBookButton => Browser.FindElement(By.Id("sidebar_btn_newbook"));
        public static IWebElement PopUpOkButton => Browser.FindElement(By.XPath("//button[@class='confirm prod_button']")); 
        public static IWebElement XlBookOption => Browser.FindElement(By.XPath("//div[@data-format='xl_photobook']"));
        public static IWebElement MaxiBookOption => Browser.FindElement(By.XPath("//div[@data-format='maxi']"));
        public static IWebElement MaxiPanoramaBookOption => Browser.FindElement(By.XPath("//div[@data-format='maxi_panorama']"));
        public static IWebElement ClassicBookOption => Browser.FindElement(By.XPath("//div[@data-format='classic']"));
        public static IWebElement SquareBookOption => Browser.FindElement(By.XPath("//div[@data-format='square']"));
        public static IWebElement PanoramaBookOption => Browser.FindElement(By.XPath("//div[@data-format='panorama']"));
        public static IWebElement CreateANewBookButton => Browser.FindElement(By.Id("new_book_button"));
        public static IWebElement PlusButton => Browser.FindElement(By.Id("page_plus"));
        public static IWebElement MinusButton => Browser.FindElement(By.Id("page_minus"));
        public static IWebElement FinalPageNumber => Browser.FindElement(By.XPath("//li[@class='last']//div[@class='number']"));
        public static IWebElement AddPagesInput => Browser.FindElement(By.Id("num_pages"));
        public static IWebElement MyPicturesBtn => Browser.FindElement(By.Id("sidebar_tab_images"));
        public static IWebElement UploadPhotosBtn => Browser.FindElement(By.Id("import_btn"));
        public static IWebElement UploadMessage => Browser.FindElement(By.XPath("//div[@id='images_upload_container']/div[1]/span"));
        public static IWebElement UploadErrorMessage => Browser.FindElement(By.Id("error_message"));
        public static IWebElement SizeOfBook => Browser.FindElement(By.Id("project_title"));
        public static IWebElement RemovePagesInput => Browser.FindElement(By.Id("num_pages"));
        public static IWebElement LibraryButton => Browser.FindElement(By.Id("sidebar_btn_projectmanager"));
        public static IList<IWebElement> BooksList => Browser.FindElements(By.XPath("//*[@id='project_manager_inner']/div"));
        public static IList<IWebElement> DeleteButtonsList => Browser.FindElements(By.XPath("//*[@class='pm-btn pm-btn-delete']"));
        public static IWebElement ConfirmPasswordField => Browser.FindElement(By.Id("confirm_pwd"));
        public static IWebElement ConfirmDeleteButton => Browser.FindElement(By.Id("confirm_delete_btn"));
        public static IWebElement DeleteAccountButton => Browser.FindElement(By.Id("pm_delete_account"));
        public static IWebElement TypesOfBookBtn => Browser.FindElement(By.Id("sidebar_btn_binding"));
        public static IList<IWebElement> BookTypesList => Browser.FindElements(By.XPath("//div[@id='binding_inner']/div"));
        public static IWebElement ApplyBindingBtn => Browser.FindElement(By.Id("apply_binding_button"));
        public static IWebElement SelectedBookType => Browser.FindElement(By.XPath("//div[@class='binding-selectable binding-selected']/span"));
        public static IList<IWebElement> DesignElements => Browser.FindElements(By.XPath("//*[@id='design_inner']//div[@class = 'design-box']"));
        public static IWebElement ChangeDesignBtn => Browser.FindElement(By.Id("sidebar_btn_design"));
        public static IWebElement DesignOkBtn => Browser.FindElement(By.Id("apply_design_button"));
        public static IWebElement MyTextBtn => Browser.FindElement(By.Id("sidebar_tab_texts"));
        public static IWebElement AddSpineTextBtn => Browser.FindElement(By.XPath("//input[@class='spine-txt-btn sidebar-panes-button']")); public static IWebElement TextEditor => Browser.FindElement(By.XPath("//body[@id='tinymce']")); public static IWebElement ConfirmInputButton => Browser.FindElement(By.Id("write_text_send"));
        public static IList<IWebElement> PageTemplatesList => Browser.FindElements(By.XPath("//div[@id='template_pages_container']/div"));
        public static IList<IWebElement> PagesList => Browser.FindElements(By.CssSelector("#thumbnails div[id^='page'][data-acceptdrop='page_template user_template']"));
        public static IWebElement ExpandFirstImageFolderBtn => Browser.FindElement(By.XPath("(//div[@class='img-group-expand inline-block expand'])[1]"));
        public static IWebElement SelectFirstImage => Browser.FindElement(By.XPath("(//div[@class='photo_image noselect lazy'])[1]"));
        public static IWebElement TrashCan => Browser.FindElement(By.Id("trash"));
        public static IWebElement PageTemplateButton => Browser.FindElement(By.Id("sidebar_tab_templates"));
        public static IList<IWebElement> TemplatesWithText => Browser.FindElements(By.XPath("//div[@id='template_pages_container']/div/div[@class='placeholder-text']"));
        public static IList<IWebElement> TemplatesWithImage => Browser.FindElements(By.XPath("//div[@id='template_pages_container']/div/div[@class='placeholder-image']"));
        public static IWebElement FreeImagesBtn => Browser.FindElement(By.Id("project_-1"));
        public static IList<IWebElement> Images => Browser.FindElements(By.XPath("//div[@id='project_-1']/parent::div/following-sibling::div//child::div[@data-page='-1']"));
        public static IList<IWebElement> PagesWithTextField => Browser.FindElements(By.CssSelector("#thumbnails div[id^='page'][data-acceptdrop='page_template user_template'] div[class='placeholder-text']"));
        public static IList<IWebElement> PagesWithImageField => Browser.FindElements(By.CssSelector("#thumbnails div[id^='page'][data-acceptdrop='page_template user_template'] div[class='placeholder-image']"));
        public static IWebElement AlertMsgBox => Browser.FindElement(By.Id("alert-message-box"));
        public static IWebElement TrashContainer => Browser.FindElement(By.Id("trash_view_inner"));
        public static IWebElement TrashFirstElement => Browser.FindElement(By.XPath("(//div[@class='text_entry trash-entry'])[1]"));
        public static IWebElement FirstPageContent => Browser.FindElement(By.Id("page_1_0"));
        public static IWebElement FinalPage => Browser.FindElement(By.XPath("//div[@class='image thumb_page']"));
        public static IWebElement DoNotDeleteButton => Browser.FindElement(By.XPath("//*[@class='abort prod_button']"));
        public static IWebElement CustomBackgroundBtn => Browser.FindElement(By.Id("sidebar_tab_backgrounds"));
        public static IWebElement BackgroundGoRightBtn => Browser.FindElement(By.Id("design_editor_right"));
        public static IWebElement BackgroundGoLeftBtn => Browser.FindElement(By.Id("design_editor_left"));
        public static IList<IWebElement> DesignPageOptions => Browser.FindElements(By.XPath("//select[@id='design_page_select']/option"));
        public static IWebElement UseEntireSpreadBtn => Browser.FindElement(By.Id("page_design_use_spread"));
        public static IWebElement SpreadImageFieldEmpty => Browser.FindElement(By.Id("page_design_color"));
        public static IWebElement SpreadImageFieldNotEmpty => Browser.FindElement(By.XPath("page_design_image"));
        public static IWebElement ClosePreview => Browser.FindElement(By.Id("page_design_editor_close"));
        public static IWebElement ImageSpreaded => Browser.FindElement(By.XPath("//div[@class='page-design-image-right page_design_div design-removable']/img"));
        public static IWebElement SinglePageDesigned => Browser.FindElement(By.Id("page_design_image"));
        public static IWebElement BackFromLibraryButton => Browser.FindElement(By.XPath("//input[@class='pm-back overlay_hide right']")); public static IWebElement CoverImageField => Browser.FindElement(By.Id("page_0_100"));
        public static IWebElement ImageEditor => Browser.FindElement(By.XPath("//*[@id='image_editor']")); 
        public static IWebElement CropImage => Browser.FindElement(By.XPath("//div[@class='jcrop-holder']/div[@class='jcrop-tracker']"));
        public static IWebElement CroppedImageDetails => Browser.FindElement(By.XPath("//*[@id='image_editor_canvas']/div/div[1]"));
        public static IWebElement SaveCroppedImageButton => Browser.FindElement(By.Id("img_editor_save"));
        public static IWebElement OrderButton => Browser.FindElement(By.Id("order_button"));
        public static IWebElement OrderPopUpButton => Browser.FindElement(By.CssSelector("#confirm-message-box > div > button.confirm.prod_button"));
        public static IWebElement OrderForm => Browser.FindElement(By.Id("order"));
        public static IWebElement CoverPageEmpty => Browser.FindElement(By.XPath("//div[@class='page-design-image-left page_design_div']"));
        public static IWebElement CoverPageNotEmpty => Browser.FindElement(By.XPath("//div[@class='page-design-image-left page_design_div design-removable']"));
        public static IWebElement CoverPageDesigned => Browser.FindElement(By.XPath("//div[@class='page-design-image-left page_design_div design-removable']/img"));
        public static IWebElement LowResolutionImage => Browser.FindElement(By.XPath("//div[@class='image_group_images']/div[@is_low_res='1'][1]"));
        public static IWebElement CannotCropMessage => Browser.FindElement(By.XPath("//*[@id='checkbox_aspect_ratio' and @disabled]"));
        public static IWebElement InviteOthersBtn => Browser.FindElement(By.Id("sidebar_tab_invites"));
        public static IWebElement InviteBtn => Browser.FindElement(By.Id("invite_button"));
        public static IWebElement ContactInfoWindow => Browser.FindElement(By.Id("details"));
        public static IWebElement FirstNameField => Browser.FindElement(By.Id("details_firstname"));
        public static IWebElement LastNameField => Browser.FindElement(By.Id("details_lastname"));
        public static IWebElement PhoneField => Browser.FindElement(By.Id("details_phone"));
        public static IWebElement SendDetailsBtn => Browser.FindElement(By.Id("send_details_button"));
        public static IWebElement RespondentInfoWindow => Browser.FindElement(By.Id("invite"));
        public static IWebElement RespondentNameField => Browser.FindElement(By.Id("invite_name"));
        public static IWebElement RespondentEmailField => Browser.FindElement(By.Id("invite_email"));
        public static IWebElement SendInvitationBtn => Browser.FindElement(By.Id("invite_button_send"));
        public static IWebElement InvitationSentMessage => Browser.FindElement(By.Id("alert-message-box"));
        public static IWebElement InvitationOKBtn => Browser.FindElement(By.XPath("//button[@class='exitBtn exit-from-messageBox prod_button']"));
        public static IWebElement BackToMyBookBtn => Browser.FindElement(By.XPath("//input[@class='invite-btn-close overlay_hide']"));
        public static IWebElement InvitationSentBox => Browser.FindElement(By.XPath("(//div[@class='text_entry noselect drag'])[1]"));
        public static void SpinnerWait() => Browser.FindElement(By.Id("spinner")).WaitTillElementDisappears();    
        public static IWebElement HomepageInterface => Browser.FindElement(By.CssSelector("body"));
        public static IWebElement ImageFolder => Browser.FindElement(By.XPath("//div[text()='Book project']"));
        public static IWebElement PreivewButton => Browser.FindElement(By.Id("sidebar_btn_preview"));
        public static IWebElement PreivewNextButton => Browser.FindElement(By.Id("preview_button_next"));
        public static IWebElement PreivewPreviousButton => Browser.FindElement(By.Id("preview_button_back"));
        public static IList<IWebElement> PreviewAreas => Browser.FindElements(By.XPath("//div[@id='preview_area']/div"));
        public static IWebElement PreviewWindow => Browser.FindElement(By.Id("preview"));
        public static IWebElement PreviewToEndButton => Browser.FindElement(By.Id("preview_button_tolast"));
        public static IWebElement PreviewToFirstButton => Browser.FindElement(By.Id("preview_button_tofirst"));
        public static IList<IWebElement> PreviewAreaSelect => Browser.FindElements(By.XPath("//select[@id='preview_select']//option"));
        public static IWebElement UploadHundredWarning => Browser.FindElement(By.XPath("//div[@class='info-msg upload_container_message']"));
        public static IWebElement Spinner => Browser.FindElement(By.Id("spinner"));
        public static IWebElement ConfirmMsgBox => Browser.FindElement(By.Id("confirm-message-box"));
        public static IWebElement ShowAllBtn => Browser.FindElement(By.Id("expand_all"));
        public static IWebElement ErrorMessageForExistingAccount => Browser.FindElement(By.XPath("//p[@class='errorText']"));
        public static IWebElement CreateNewBookButtonInLibraryWindow => Browser.FindElement(By.Id("pm_new_book"));
        public static IList<IWebElement> ImagesGroupDisplayed => Browser.FindElements(By.XPath("//div[@class='image_group_images']"));
        public static IList<IWebElement> ImagesGroup => Browser.FindElements(By.XPath("//div[@class='image_group_title']"));
        public static IList<IWebElement> AllImages => Browser.FindElements(By.XPath("//div[@data-type='image']"));
        public static void OverlayerWait() => Browser.FindElement(By.Id("overlayer")).WaitTillElementDisappears();

        #endregion

        #region Public methods

        /// <summary>
        /// Create random size book
        /// </summary>
        /// <param name="sizeOfBook"> Enum representing size of book with default value of Random size of book from SizesOfBook enum </param>
        /// <param name="user"> Enum representing type of user with default value of Existing type of user from TypeOfUser enum </param>

        public static void CreateBook(SizesOfBook sizeOfBook = SizesOfBook.Random, TypeOfUser user = TypeOfUser.Existing)
        {
            if (user == TypeOfUser.Existing)
            {
                SpinnerWait();
                OverlayerWait();
                NewBookButton.WaitForVisible();
                NewBookButton.ClickJs();
                ConfirmMsgBox.WaitForVisible();
                PopUpOkButton.ClickWait();
            }

            if (sizeOfBook == SizesOfBook.Random)
            {
                sizeOfBook = (SizesOfBook)GetRandomBook();
            }

            switch (sizeOfBook)
            {
                case SizesOfBook.Xl:
                    {
                        XlBookOption.ClickWait();
                        log.Info("Book of size XL is chosen");
                        break;
                    }
                case SizesOfBook.Maxi:
                    {
                        MaxiBookOption.ClickWait();
                        log.Info("Book of size Maxi is chosen");
                        break;
                    }
                case SizesOfBook.MaxiPanorama:
                    {
                        MaxiPanoramaBookOption.ClickWait();
                        log.Info("Book of size Maxi Panorama is chosen");
                        break;
                    }
                case SizesOfBook.Classic:
                    {
                        ClassicBookOption.ClickWait();
                        log.Info("Book of size Classic is chosen");
                        break;
                    }
                case SizesOfBook.Square:
                    {
                        SquareBookOption.ClickWait();
                        log.Info("Book of size Square is chosen");
                        break;
                    }
                case SizesOfBook.Panorama:
                    {
                        PanoramaBookOption.ClickWait();
                        log.Info("Book of size Panorama is chosen");
                        break;
                    }
            }
            CreateANewBookButton.ClickWait();
            SpinnerWait();
            OverlayerWait();
            ProjectHandler.BookCreated = sizeOfBook;
            log.Info("The new book is created");
        }

        /// <summary>
        /// This method adds or removes pages from book
        /// It can add and remove pages, out of scope or in scope
        /// </summary>
        /// <param name="inScope"> Boolean value representing if number to add is in or out of range, with default value of true </param>
        /// <param name="add"> Boolean value representing adding or removing pages, with default value of true </param>
        public static void AddOrRemovePages(bool inScope = true, bool add = true)
        {
            Thread.Sleep(1000);
            int numberOfPagesToEnter;
            ProjectHandler.isNumberInOrOutOfRange = inScope;
            var createdBookSize = Enum.GetName(typeof(SizesOfBook), ProjectHandler.BookCreated);
            string limitsOfBook = TestData.bookDetails[createdBookSize][ProjectHandler.TypeOfBook];
            string[] limits = limitsOfBook.Split(' ');
            Int32.TryParse(FinalPageNumber.Text, out int numberOfPagesInBookBeforeAction);
            Int32.TryParse(limits[0], out int lowerLimitOfPages);
            Int32.TryParse(limits[1], out int upperLimitOfPages);
            ProjectHandler.PreviousFinalPageNumber = numberOfPagesInBookBeforeAction;
            log.Info($"Book has: {ProjectHandler.PreviousFinalPageNumber} pages.");

            if (inScope == true && add == true)
            {
                if (numberOfPagesInBookBeforeAction == upperLimitOfPages)
                {
                    log.Info("Maximum number of pages is equal to number of pages, it needs to remove some pages first");
                    AddOrRemovePages(true, false);
                    SpinnerWait();
                    Thread.Sleep(1000);
                    Int32.TryParse(FinalPageNumber.Text, out numberOfPagesInBookBeforeAction);
                }
                numberOfPagesToEnter = GetRandomNumber(upperLimitOfPages - numberOfPagesInBookBeforeAction + 1);
                log.Info($"Pages will be added in scope. Number of pages to add: {numberOfPagesToEnter}");
            }
            else if (inScope == true && add == false)
            {
                if (numberOfPagesInBookBeforeAction == lowerLimitOfPages)
                {
                    log.Info("Minimum number of pages is equal to number of pages, it needs to add some pages first");
                    AddOrRemovePages(true, true);
                    SpinnerWait();
                    Thread.Sleep(1000);
                    Int32.TryParse(FinalPageNumber.Text, out numberOfPagesInBookBeforeAction);
                }
                numberOfPagesToEnter = GetRandomNumber(numberOfPagesInBookBeforeAction - lowerLimitOfPages + 1);
                log.Info($"Pages will be removed in scope.Number of pages to remove: {numberOfPagesToEnter}");
            }
            else if (inScope == false && add == true)
            {
                numberOfPagesToEnter = GetRandomNumber(1000, upperLimitOfPages - numberOfPagesInBookBeforeAction + 2);
                log.Info($"Pages will be added out of scope. Number of pages to add: {numberOfPagesToEnter}");
            }
            else
            {
                numberOfPagesToEnter = GetRandomNumber(1000, numberOfPagesInBookBeforeAction - lowerLimitOfPages + 2);
                log.Info($"Pages will be removed out of scope. number of pages to remove: {numberOfPagesToEnter}");
            }
            ProjectHandler.PreviousFinalPageNumber = numberOfPagesInBookBeforeAction;
            ProjectHandler.NumberOfPagesToAddOrRemove = numberOfPagesToEnter;
            AddPagesInput.Clear();
            AddPagesInput.SendKeys(numberOfPagesToEnter.ToString());
            if (add)
            {
                PlusButton.ClickWait();
                ProjectHandler.isAddedOrRemoved = true;
                log.Info($"Pages are added.");
            }
            else
            {
                MinusButton.ClickWait();
                ProjectHandler.isAddedOrRemoved = false;
                log.Info($"Pages are removed.");
            }
            if (!inScope)
            {
                OkButton.ClickWait();
            }
            else
            {
                SpinnerWait();
            }
        }

        /// <summary>
        /// Upload photos from computer
        /// </summary>
        /// <param name="image"> String representing name of the image for upload, as well as image extension, with default value of "testimage.jpg" </param>
        public static void UploadPhotos(string image = "testimage.jpg")
        {
            SpinnerWait();
            OverlayerWait();
            MyPicturesBtn.ClickWait();
            UploadPhotosBtn.ClickWait();
            FileUpload.SendKeys(GeneralTestData.GetFullJsonPath(image));
            SpinnerWait();
            log.Info($"Image file {image} is input");
        }

        /// <summary>
        /// Delete images from folder
        /// </summary>
        public static void DeleteImages()
        {
            Thread.Sleep(5000);
            ExpandFirstImageFolderBtn.ClickWait();
            SelectFirstImage.WaitForVisible();
            DragAndDropElement(SelectFirstImage, TrashCan);
            log.Info("The image file is moved to trash can");
        }

        /// <summary>
        /// Change Design of Book
        /// </summary>
        public static void ChangeBookDesign()
        {
            ChangeDesignBtn.ClickWait();
            int randomDesign = GetRandomNumber(DesignElements.Count);
            IWebElement design = DesignElements[randomDesign];
            design.Click();
            var designText = design.Text;
            var reg = new Regex("\".*?\"");
            var matches = reg.Matches(designText);
            string extractedDesignName = string.Empty;
            foreach (var item in matches)
            {
                extractedDesignName = item.ToString().Trim('"');
            }
            DesignOkBtn.ClickWait();
            SpinnerWait();
            ProjectHandler.ExtractedDesignName = extractedDesignName;
            log.Info("Book design is set to be changed");
        }

        /// <summary>
        /// Delete created book project
        /// </summary>
        public static void DeleteProject()
        {
            SpinnerWait();
            OverlayerWait();
            LibraryButton.ClickWait();
            SpinnerWait();
            var numberOfProjects = BooksList.Count;
            if (numberOfProjects > 1)
            {
                var randomProject = GetRandomNumber(numberOfProjects);
                DeleteButtonsList[randomProject].ClickWait();
                ConfirmPasswordField.WaitForVisible();
                ConfirmPasswordField.SendKeys((String)TestData.general_password);
                ConfirmDeleteButton.ClickWait();
                ProjectHandler.NumberOfProjects = numberOfProjects;
            }
            else
            {
                CreateNewBookButtonInLibraryWindow.ClickWait();
                PopUpOkButton.ClickWait();
                CreateBook(SizesOfBook.Random, TypeOfUser.JustRegistered);
                DeleteProject();
            }
            log.Info("Book project is set for deleting");
        }
        
        /// <summary>
        /// Applying templates
        /// </summary>
        /// <param name="numberOfAppliedTemplates"> Integer value representing number of templates to be applied with default value of 3 </param>
        /// <param name="page"> Enum representing page on which template will be applied, with default value of Random page from PageType enum </param>
        /// <param name="typeOfTemplate"> Enum representing type of template that will be applied, with default value of Random template from TemplatesType enum </param>
        public static void ApplyTemplates(int numberOfAppliedTemplates = 3, PageType page = PageType.Random, TemplatesType typeOfTemplate = TemplatesType.Random)
        {
            ProjectHandler.ListOfAlreadyUsedPages.Clear();
            FirstPageContent.WaitForVisible();
            ProjectHandler.StyleOfDefaultTemplate = FirstPageContent.GetAttribute("style");
            PageTemplateButton.ClickWait();
            int counterOfDefaultTemplates = 0;
            for (int i = 0; i < numberOfAppliedTemplates; i++)
            {
                var Drag = GetRandomTemplate(typeOfTemplate);
                if (Drag.GetAttribute("id") == "template_text_full")
                    counterOfDefaultTemplates++;
                IWebElement Drop;
                if(page == PageType.LastPage)
                {
                    Drop = FinalPage;
                    log.Info("Book template will be moved to the final page");
                }
                else
                {
                    Drop = GetRandomPage();
                    log.Info($"Book template will be moved to a book page {ProjectHandler.ListOfAlreadyUsedPages[i]}.");
                }
                DragAndDropElement(Drag, Drop);
            }
            ProjectHandler.NumberOfAppliedDefaultTemplates = counterOfDefaultTemplates;
            log.Info("Book template(s) applied");

        }

        /// <summary>
        /// Drag and drop element
        /// </summary>
        /// <param name="element1"> IWebElement representing element to drag </param>
        /// <param name="element2"> IWebElement representing target element on which element1 will be dropped </param>
        private static void DragAndDropElement(IWebElement element1, IWebElement element2)
        {
            Thread.Sleep(1000);
            new Actions(Browser)
                .ClickAndHold(element1)
                .MoveToElement(element2, 2, 2)
                .Release(element2)
                .Build()
                .Perform();
            Thread.Sleep(1000);
            log.Info("Object is dragged and drop");
        }

        /// <summary>
        /// Add spine to Book Cover
        /// </summary>
        public static void AddSpine()
        {
            MyTextBtn.ClickWait();
            AddSpineTextBtn.ClickWait();
            Browser.SwitchTo().Frame("write_text_text2_ifr");
            TextEditor.SendKeys((String)TestData.spine_text);
            Browser.SwitchTo().DefaultContent();
            ConfirmInputButton.ClickWait();
            SpinnerWait();
            OverlayerWait();
            log.Info("Book spine is set to be added");
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="email"> Enum representing email, with default value of Random from Emails enum </param>
        public static void DeleteAccount(Emails email = Emails.Random)
        {
            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(3));
            string password = TestData.general_password;
            LibraryButton.ClickWait();
            DeleteAccountButton.ClickWait();
            ConfirmPasswordField.SendKeys(password);
            ConfirmDeleteButton.ClickWait();
            wait.Until(ExpectedConditions.AlertIsPresent());
            var confirm_win = Browser.SwitchTo().Alert();
            confirm_win.Accept();
            log.Info("Account is set for deleting");
        }

        /// <summary>
        /// Place random image on a needed place
        /// </summary>
        /// <param name="typeOfTemplate"> Enum representing type of page template, with default value of WithImageField from TemplatesType enum  </param>
        /// <param name="typeOfImage"> Enum representing type of image, with default value of Random from Image enum  </param>
        public static void PlaceImageOnField(TemplatesType typeOfTemplate = TemplatesType.WithImageField, Image typeOfImage = Image.Random)
        {
            SpinnerWait();
            OverlayerWait();
            IWebElement FieldToPlaceImage;
            IWebElement image;
            PageTemplateButton.ClickWait();
            if (typeOfTemplate == TemplatesType.WithImageField)
            {
                ApplyTemplates(1, PageType.Random, TemplatesType.WithImageField);
                var randomPage = PagesList[ProjectHandler.ListOfAlreadyUsedPages[0]];
                FieldToPlaceImage = randomPage.FindElement(By.CssSelector("div.placeholder-image"));
                var _imageFieldId = FieldToPlaceImage.GetAttribute("id");
                MyPicturesBtn.ClickWait();
                if (typeOfImage == Image.Random)
                {
                    FreeImagesBtn.ClickWait();
                    image = GetRandomImage();
                }
                else
                {
                    UploadPhotos((String)TestData.images.low_resolution_image);
                    SpinnerWait();
                    var numberOfBookFolders = ImagesGroup.Count;
                    while (true)
                    {
                        if (numberOfBookFolders == ImagesGroup.Count) 
                            Thread.Sleep(200);
                        else 
                            break;
                    }
                    if (ImagesGroupDisplayed[0].GetAttribute("style") == "display: none;") 
                        ImagesGroup[0].ClickWait();
                    image = LowResolutionImage;
                }
                FieldToPlaceImage = Browser.FindElement(By.Id(_imageFieldId));
                FieldToPlaceImage.WaitForVisible();
                DragAndDropElement(image, FieldToPlaceImage);
                ProjectHandler.ImageField = Browser.FindElement(By.Id(_imageFieldId));
                log.Info($"Image is placed on the {ProjectHandler.ListOfAlreadyUsedPages[0]}. page");
            }
            else
            {
                ApplyTemplates(1, PageType.Random, TemplatesType.WithTextField);
                var randomPage = PagesList[ProjectHandler.ListOfAlreadyUsedPages[0]];
                FieldToPlaceImage = randomPage.FindElement(By.CssSelector("div.placeholder-text"));
                MyPicturesBtn.ClickWait();
                FreeImagesBtn.ClickWait();
                image = GetRandomImage();
                DragAndDropElement(image, FieldToPlaceImage);
                log.Info("Image shouldn't be placed on a text field");
            }
        }

        /// <summary>
        /// Save progress after log out
        /// </summary>
        public static void SaveProgress()
        {
            AddTextToPage();
            SpinnerWait();
            OverlayerWait();
            LogoutButton.WaitForVisible();
            LogoutButton.ClickJs();
            DoNotDeleteButton.ClickWait();
            log.Info("Progress is saved");
        }

        /// <summary>
        /// Verify that user can create custom text to page
        /// </summary>
        public static void AddTextToPage ()
        {
            SpinnerWait();
            Thread.Sleep(500);
            var textField = GetRandomTextField();
            textField.WaitForVisible();
            ProjectHandler.RandomPage = int.Parse(textField.GetAttribute("data-page"));
            textField.DoubleClick();
            Browser.SwitchTo().Frame("write_text_text2_ifr");
            TextEditor.SendKeys((String)TestData.general_text);
            Browser.SwitchTo().DefaultContent();
            ConfirmInputButton.ClickWait();
            log.Info($"Custom text is added to a page {ProjectHandler.RandomPage}");
        }

        /// <summary>
        /// User can crop image
        /// </summary>
        public static void CropImages()
        {
            Actions action = new Actions(Browser);
            PlaceImageOnField();          
            var image = ProjectHandler.ImageField;
            image.DoubleClick();
            ImageEditor.WaitForVisible();
            string imageBeforeCrop = CroppedImageDetails.GetAttribute("style");
            action.ClickAndHold(CropImage).MoveByOffset(10, 20).Release().Build().Perform();
            SpinnerWait();
            SaveCroppedImageButton.ClickWait();
            ProjectHandler.ImageBeforeCrop = imageBeforeCrop;
            log.Info("Image is cropped");
        }

        /// <summary>
        /// User can invite others to contribute on the book project
        /// </summary>
        /// <param name="respondentName"> String representing respondents name with default value Test </param>
        /// <param name="respondentEmail"> String representing respondents email with default value test000@test.com </param>
        public static void InviteOthers(string respondentName = "Test", string respondentEmail = "test000@test.com")
        {
            Thread.Sleep(1000);
            InviteOthersBtn.ClickJs();
            SpinnerWait();
            InviteBtn.ClickJs();
            ContactInfoWindow.WaitForVisible();
            SpinnerWait();
            FirstNameField.SendKeys((String)TestData.first_name_field);
            LastNameField.SendKeys((String)TestData.last_name_field);
            PhoneField.SendKeys((String)TestData.phone_field);
            SendDetailsBtn.Click();
            RespondentInfoWindow.WaitForVisible();
            RespondentNameField.SendKeys(respondentName);
            RespondentEmailField.SendKeys(respondentEmail);
            SendInvitationBtn.Click();
            InvitationSentMessage.WaitForVisible();
            InvitationOKBtn.Click();
            BackToMyBookBtn.Click();
            InvitationSentBox.WaitForVisible();
            log.Info($"Invitation for contribution is set to be sent to {respondentEmail}");
        }

        public static void SwitchBookTypes()
        {
            SpinnerWait();
            OverlayerWait();
            TypesOfBookBtn.ClickWait();
            var index = GetRandomNumber(BookTypesList.Count);
            BookTypesList[index].ClickWait();
            SelectedBookType.WaitForVisible();
            var selectedBookType = SelectedBookType.Text;
            var separatorIndex = 0;
            foreach (var sign in selectedBookType)
            {
                if ((sign == 'N') || (sign == '(')) break;
                separatorIndex++;
            }
            selectedBookType = selectedBookType.Substring(0, separatorIndex - 1);
            ProjectHandler.TypeOfBook = selectedBookType;
            ApplyBindingBtn.ClickWait();
            SpinnerWait();
            log.Info($"Book type is switched to {selectedBookType}");

        }

        #endregion

        #region Validation methods

        /// <summary>
        /// Verify user login
        /// </summary>
        public static void VerifyLogin()
        {
            SpinnerWait();
            LogoutButton.WaitForVisible();
            LogoutButton.Displayed.Should().BeTrue("User should be logged in.");
            log.Info("User is logged in");
        }

        /// <summary>
        /// Verify user registration
        /// </summary>
        public static void VerifyRegistration()
        {
            Thread.Sleep(900);
            if((ErrorMessageForExistingAccount.Displayed)&&ErrorMessageForExistingAccount.Text.Equals((String)TestData.ErrorMessageForExistingAccount))
            {
                if(ProjectHandler.numberOfAttemptsToRegistrateWithGeneratedEmail <= 10)
                {
                    ++ProjectHandler.numberOfAttemptsToRegistrateWithGeneratedEmail;
                    log.Info($"Account is already created with email:{TestData.emails.GeneratedEmail}");
                    Homepage.RegistrateSolentro();
                    VerifyRegistration();
                }
                else
                {
                    ProjectHandler.numberOfAttemptsToRegistrateWithGeneratedEmail = 1;
                    log.Info("Number of attempts to get email which does not have account created is bigger than 10");
                    throw new ArgumentException((String)AssertionData.ShouldNotGenerateMoreThanTenEmails);
                }                
            }
            else
            {
                CreateANewBookButton.WaitForVisible();
                CreateANewBookButton.Displayed.Should().BeTrue((String)AssertionData.Registration);
                log.Info($"User is registered succesfully with email:{TestData.emails.GeneratedEmail}");
                ProjectHandler.numberOfAttemptsToRegistrateWithGeneratedEmail = 1;
            }
        }

        /// <summary>
        /// User can customize background
        /// Verify that background is customized
        /// </summary>
        public static void VerifyCustomizeBackground()
        {
            SpinnerWait();
            OverlayerWait();
            CustomBackgroundBtn.ClickWait();
            FreeImagesBtn.ClickJs();
            var chosenImage = GetRandomImage();
            try
            {
                if(CoverPageEmpty.Displayed == true)
                    DragAndDropElement(chosenImage, CoverPageEmpty);
            }
            catch 
            {
                DragAndDropElement(chosenImage, CoverPageNotEmpty);
            }
            CoverPageDesigned.Displayed.Should().BeTrue((String)AssertionData.CustomizeBackground);
            ClosePreview.ClickWait();
            log.Info("Background is customized");
        }

        /// <summary>
        /// User can design single book page with photos
        /// Verify that single page is designed with photo
        /// </summary>
        public static void VerifyDesignSinglePageWithPhoto()
        {
            SpinnerWait();
            OverlayerWait();
            CustomBackgroundBtn.ClickWait();
            BackgroundGoRightBtn.ClickWait();
            BackgroundGoLeftBtn.ClickWait();
            int randomDesignPage = GetRandomNumber(DesignPageOptions.Count);
            var chosenPage = DesignPageOptions[randomDesignPage];
            chosenPage.ClickWait();
            FreeImagesBtn.ClickJs();
            var chosenImage = GetRandomImage();
            try
            {
                if (SpreadImageFieldEmpty.Displayed == true)
                    DragAndDropElement(chosenImage, SpreadImageFieldEmpty);
            }
            catch 
            {
                DragAndDropElement(chosenImage, SpreadImageFieldNotEmpty);
            }
            SinglePageDesigned.Displayed.Should().BeTrue((String)AssertionData.SinglePage);
            ClosePreview.ClickWait();
            log.Info("Page is designed with a photo");
        }

        /// <summary>
        /// User can spread image on two pages
        /// Verify that image is spreaded
        /// </summary>
        public static void VerifySpreadImageOnTwoPages()
        {
            SpinnerWait();
            OverlayerWait();
            CustomBackgroundBtn.ClickWait();
            BackgroundGoRightBtn.ClickWait();
            BackgroundGoLeftBtn.ClickWait();
            int randomDesignPage = GetRandomNumber(DesignPageOptions.Count);
            if (randomDesignPage < 2)
            {
                randomDesignPage = 2;
            }
            var chosenPage = DesignPageOptions[randomDesignPage];
            chosenPage.ClickWait();
            UseEntireSpreadBtn.ClickWait();
            FreeImagesBtn.WaitForVisible();
            FreeImagesBtn.ClickJs();
            IWebElement chosenImage = GetRandomImage();
            try
            {
                if (SpreadImageFieldEmpty.Displayed == true)
                    DragAndDropElement(chosenImage, SpreadImageFieldEmpty);
            }
            catch
            {
                DragAndDropElement(chosenImage, SpreadImageFieldNotEmpty);
            }
            SpinnerWait();
            ImageSpreaded.Displayed.Should().BeTrue((String)AssertionData.SpreadImage);
            ClosePreview.ClickWait();
            log.Info("Image is spreaded on two pages.");
        }


        /// <summary>
        /// Verify that user can switch book types
        /// </summary>
        public static void VerifySwitchBookTypes()
        {
            var selectedBookType = ProjectHandler.TypeOfBook;
            var bookType = GetBookType();
            SpinnerWait();
            bookType.Contains(selectedBookType).Should().BeTrue((String)AssertionData.SwitchType);
            log.Info($"Book type is correctly switched");
        }

        /// <summary>
        /// Verify that book is created
        /// </summary>
        public static void VerifyCreatedBook()
        {
            Thread.Sleep(500);
            var actualSizeOfBook = GetBookSize();
            var bookSize = Enum.GetName(typeof(SizesOfBook), ProjectHandler.BookCreated);
            string expectedBookSize = TestData.sizeOfBooks[bookSize];
            expectedBookSize.Equals(actualSizeOfBook).Should().BeTrue((String)AssertionData.CreateBook);
            log.Info("Correct size of book is created");
        }

        /// <summary>
        /// Verify that design is applied
        /// </summary>
        public static void VerifyDesignIsChanged()
        {
            SpinnerWait();
            var BookInfo = SizeOfBook.Text;
            var separatorIndex = 0;
            var counter = 0;

            foreach (var sign in BookInfo)
            {
                if (sign == ':') counter++;
                if (counter == 2) break;
                separatorIndex++;
            }
            var separatedBookInfo = BookInfo.Substring(separatorIndex + 2);

            var separatorIndex2 = 0;
            foreach (var sign in separatedBookInfo)
            {
                if ((sign == ',')) break;
                separatorIndex2++;
            }
            var DesignInfo = separatedBookInfo.Substring(0, separatorIndex2);

            ProjectHandler.ExtractedDesignName.Equals(DesignInfo).Should().BeTrue((String)AssertionData.ChangeDesign);
            log.Info("Design of the book is changed");
        }

        /// <summary>
        /// Verify that project is deleted
        /// </summary>
        public static void VerifyDeleteProject()
        {
            SpinnerWait();
            if (!DeleteAccountButton.Displayed)
            {
                Thread.Sleep(500);
                if (!DeleteAccountButton.Displayed)
                {
                    OverlayerWait();
                    LibraryButton.ClickWait();
                }
            }
            DeleteAccountButton.WaitForVisible();
            var numberOfProjectsAfterDeletion = BooksList.Count;
            if (numberOfProjectsAfterDeletion == ProjectHandler.NumberOfProjects)
            {
                SpinnerWait();
                numberOfProjectsAfterDeletion = BooksList.Count;
            }
            numberOfProjectsAfterDeletion.Equals(ProjectHandler.NumberOfProjects - 1).Should().BeTrue((String)AssertionData.DeleteProject2);
            log.Info("Project is deleted");
        }

        /// <summary>
        /// Verify that spine is added to Book Cover
        /// </summary>
        public static void VerifyAddSpine()
        {
            AddSpineTextBtn.ClickWait(); ;
            Browser.SwitchTo().Frame("write_text_text2_ifr");
            var bodyText = (String)TextEditor.Text;
            bodyText.Equals((String)TestData.spine_text).Should().BeTrue((String)AssertionData.AddSpine);
            Browser.SwitchTo().DefaultContent();
            ConfirmInputButton.ClickWait();
            log.Info("Spine is added");
        }

        /// <summary>
        /// Verify that user cannot upload more than 100 images
        /// </summary>
        public static void VerifyCannotUpload101Images()
        {
            SpinnerWait();
            OverlayerWait();
            MyPicturesBtn.ClickWait();
            UploadPhotosBtn.ClickWait();
            string fullPath = GeneralTestData.GetFullJsonPath(@"/101TestPhotos/");
            var fileList = new List<string>();
            for (int i = 0; i < 101; i++ )
            {
                var image = TestData.Images[i];
                string File = fullPath + Convert.ToString(image);
                string filePath = Path.Combine(fullPath, File);
                fileList.Add(filePath);
            }
            FileUpload.SendKeys(Path.GetFullPath(string.Join("\n", fileList)));
            Spinner.WaitTillElementDisappears(300);
            log.Info("Bundle of 101 images can not be uploaded");
            UploadHundredWarning.Displayed.Should().BeTrue((String)AssertionData.Upload101Images);
        }

        /// <summary>
        /// Verify that photo is uploaded
        /// </summary>
        public static void VerifyUploadPhotos()
        {
            var actualNumberOfUploadedImages = UploadMessage.Text.Substring(0, 1);
            var expectedNumberOfUploadedImages = UploadMessage.Text.Substring(5, 1);
            actualNumberOfUploadedImages.Equals(expectedNumberOfUploadedImages).Should().BeTrue((String)AssertionData.UploadPhotos);
            log.Info("Image is uploaded");
        }

        /// <summary>
        /// Verify that photo is deleted
        /// </summary>
        public static void VerifyDeleteImages()
        {
            TrashCan.ClickWait();
            TrashContainer.WaitForVisible();
            TrashFirstElement.Displayed.Should().BeTrue((String)AssertionData.DeleteImage);
            log.Info("Image is deleted");
        }

        /// <summary>
        /// Verify that progress is saved after log out
        /// </summary>
        public static void VerifySavedProgress()
        {
            SpinnerWait();
            OverlayerWait();
            var PageToVerify = PagesList[ProjectHandler.RandomPage - 1];
            PageToVerify.WaitForVisible();
            PageToVerify.DoubleClick();
            Browser.SwitchTo().Frame("write_text_text2_ifr");
            var bodyText = (String)TextEditor.Text;
            bodyText.Equals((String)TestData.general_text).Should().BeTrue((String)AssertionData.SavedProgress);
            log.Info("Progress is saved");
        }

        /// <summary>
        /// Verify that final page is not editable
        /// </summary>
        public static void VerifyFinalPageNotEditable()
        {
            ApplyTemplates(1, PageType.LastPage);
            Thread.Sleep(500);
            AlertMsgBox.WaitForVisible();
            AlertMsgBox.Displayed.Should().BeTrue((String)AssertionData.FinalPage);
            log.Info("Final page is not suitable for edit");
        }

        /// <summary>
        /// Verify that user cannot upload file of invalid format 
        /// </summary>
        public static void VerifyInvalidImageFormatCannotBeUploaded()
        {
            UploadPhotos("bad_input.txt");
            UploadErrorMessage.Displayed.Should().BeTrue((String)AssertionData.InvalidImageFormat);
            log.Info("File of non-image format is not uploaded");
        }

        /// <summary>
        /// Verify that user has multiple books at the same time
        /// </summary>
        public static void VerifyHavingMultipleBooks()
        {
            SpinnerWait();
            OverlayerWait();
            LibraryButton.ClickWait();
            var numberOfBooksBefore = BooksList.Count;
            BackFromLibraryButton.ClickWait();
            CreateBook(SizesOfBook.Random, TypeOfUser.Existing);
            LibraryButton.ClickWait();
            BackFromLibraryButton.WaitForVisible();
            var numberOfBooksAfter = BooksList.Count;
            numberOfBooksAfter.Equals(numberOfBooksBefore + 1).Should().BeTrue((String)AssertionData.MultipleBooks);
            log.Info("User has multiple books at the same time");
        }

        /// <summary>
        /// Verify that user can create custom page templates in a book
        /// </summary>
        /// <param name="xValue"> Integer value representing value on the x-axis to be manipluated with, with default value of 72 </param>
        public static void VerifyUserCanCreateCustomTemplates(int xValue = 72)
        {
            SpinnerWait();
            CustomizeBtn.ClickWait();
            UserTemplateBtn.ClickWait();
            var numberOfTemplatesBefore = CheckSavedTempate.Count;
            TEAddImage.ClickWait();
            XTemplate.Clear();
            XTemplate.SendKeys(xValue.ToString());
            TEAddText.ClickWait();
            TemplateSaveBtn.ClickWait();
            TemplateCloseBtn.ClickWait();
            var numberOfTemplatesAfter = CheckSavedTempate.Count;
            numberOfTemplatesAfter.Equals(numberOfTemplatesBefore + 1).Should().BeTrue((String)AssertionData.CustomTemplate);
            SpinnerWait();
            log.Info("Custom template is created");
        }

        /// <summary>
        /// Verify that user can place order
        /// </summary>
        public static void VerifyThatUserCanPlaceOrder()
        {
            OverlayerWait();
            OrderButton.ClickWait();
            OrderPopUpButton.ClickWait();
            OrderForm.Displayed.Should().BeTrue((String)AssertionData.PlaceOrder);
            log.Info("Order is placed");
        }

        /// <summary>
        /// Verify that image is cropped
        /// </summary>
        public static void VerifyImageIsCropped()
        {
            var image = ProjectHandler.ImageField;
            image.WaitForVisible();
            image.DoubleClick();
            string imageAfterCrop = CroppedImageDetails.GetAttribute("style");
            ProjectHandler.ImageBeforeCrop.Equals(imageAfterCrop).Should().BeFalse((String)AssertionData.CropImage);
            log.Info("Image is cropped");
        }

        /// <summary>
        /// User cannot crop image with low resolution
        /// </summary>
        public static void VerifyUserCannotCropLowResolutionImage()
        {
            PlaceImageOnField(TemplatesType.WithImageField, Image.LowResolution);
            var image = ProjectHandler.ImageField;
            image.DoubleClick();
            CannotCropMessage.Selected.Should().BeFalse((String)AssertionData.CannotCrop);
            SaveCroppedImageButton.ClickWait();
            log.Info($"Low resolution image {TestData.images.low_resolution_image} is not cropped");
        }

        /// <summary>
        /// Method is used after ApplyTemplates to verify all 3 templates are applied
        /// </summary>
        public static void VerifyAppliedTemplates()
        {
            Thread.Sleep(200);
            int counterOfAppliedTemplates = 0;
            for (int i = 0; i < ProjectHandler.ListOfAlreadyUsedPages.Count; i++)
            {
                PagesList[ProjectHandler.ListOfAlreadyUsedPages[i]].WaitForVisible();
                var template = PagesList[ProjectHandler.ListOfAlreadyUsedPages[i]].FindElement(By.CssSelector("div"));
                template.WaitForVisible();
                if (template.GetAttribute("style") != ProjectHandler.StyleOfDefaultTemplate || 
                    (template.GetAttribute("style") == ProjectHandler.StyleOfDefaultTemplate && template.GetAttribute("data-acceptdrop") != "page_template user_template text" ))
                    counterOfAppliedTemplates++;
                if (counterOfAppliedTemplates == 3)
                    break;
            }
            counterOfAppliedTemplates.Equals(3 - ProjectHandler.NumberOfAppliedDefaultTemplates).Should().BeTrue("All templates are applied");
        }

        /// <summary>
        /// The method verifies that pages are added or removed properrly from book
        /// The method also verifies that non page is added if it tryed to add out of scope
        /// </summary>
        public static void VerifyThatPagesAreAddedOrRemovedInOrOutOfScope()
        {
            var addedOrRemovedPages = ProjectHandler.NumberOfPagesToAddOrRemove;
            Thread.Sleep(500);
            Int32.TryParse(FinalPageNumber.Text, out int numberOfPagesInBookAfterAction);
            if (ProjectHandler.TypeOfBook.Equals("Staple bound"))
            {
                if(addedOrRemovedPages < 8)
                {
                    addedOrRemovedPages = 4;
                }    
                else if(addedOrRemovedPages % 4 != 0)
                {
                    addedOrRemovedPages = addedOrRemovedPages - addedOrRemovedPages % 4;
                }
                log.Info("Book type is staple book. 4, 8, 12.... pages can be added or removed.");
            }
            else
            {
                if (addedOrRemovedPages < 2)
                {
                    addedOrRemovedPages = 2;

                }
                else if (addedOrRemovedPages % 2 != 0)
                {
                    addedOrRemovedPages -= 1;
                }
            }
            if (ProjectHandler.isAddedOrRemoved == true && ProjectHandler.isNumberInOrOutOfRange == true)
            {
                log.Info($"Number of pages excpectet to be {ProjectHandler.PreviousFinalPageNumber + addedOrRemovedPages}");
                numberOfPagesInBookAfterAction.Equals(ProjectHandler.PreviousFinalPageNumber + addedOrRemovedPages).Should().BeTrue((String)AssertionData.AddedOrRemovedPages);
            }
            else if (ProjectHandler.isAddedOrRemoved == false && ProjectHandler.isNumberInOrOutOfRange == true)
            {
                log.Info($"Number of pages excpectet to be {ProjectHandler.PreviousFinalPageNumber - addedOrRemovedPages}");
                numberOfPagesInBookAfterAction.Equals(ProjectHandler.PreviousFinalPageNumber - addedOrRemovedPages).Should().BeTrue((String)AssertionData.AddedOrRemovedPages);
            }
            else
            {
                log.Info($"Number of pages excpectet to be {ProjectHandler.PreviousFinalPageNumber}");
                numberOfPagesInBookAfterAction.Equals(ProjectHandler.PreviousFinalPageNumber).Should().BeTrue((String)AssertionData.ShouldNotAddOrRemove);
            }
        }

        /// <summary>
        /// Verify that contributed image is uploaded
        /// </summary>
        public static void VerifyContributedImageIsUploaded()
        {
            SpinnerWait();
            OverlayerWait();
            HomepageInterface.WaitForVisible();
            MyPicturesBtn.ClickWait();
            ImageFolder.WaitForVisible();
            ExpandFirstImageFolderBtn.ClickWait();
            SelectFirstImage.WaitForVisible();
            log.Info("Contributed image is uploaded");
        }

        /// <summary>
        /// Verify that registered user can preview book
        /// </summary>
        public static void VerifyPreviewBook()
        {
            PreivewButton.ClickWait();
            PreviewWindow.WaitForVisible();
            var numberOfAreas = PreviewAreas.Count;
            PreviewAreas[0].Displayed.Should().BeTrue((String)AssertionData.AreaNotDisplayed);
            for (int i = 1; i < numberOfAreas; i++)
            {
                PreivewNextButton.Click();
                PreviewAreas[i].Displayed.Should().BeTrue((String)AssertionData.AreaNotDisplayed);
            }
            for(int i = numberOfAreas - 2; i >= 0; i--)
            {
                PreivewPreviousButton.Click();
                PreviewAreas[i].Displayed.Should().BeTrue((String)AssertionData.AreaNotDisplayed);
            }
            PreviewToEndButton.Click();
            PreviewAreas[numberOfAreas-1].Displayed.Should().BeTrue((String)AssertionData.AreaNotDisplayed);
            PreviewToFirstButton.Click();
            PreviewAreas[0].Displayed.Should().BeTrue((String)AssertionData.AreaNotDisplayed);
            var randomAreaNumber = GetRandomNumber(PreviewAreaSelect.Count);
            var AreaSelecte = PreviewAreaSelect[randomAreaNumber];
            AreaSelecte.Click();
            PreviewAreas[randomAreaNumber].Displayed.Should().BeTrue("Area of current selected page is not displayed.");
            log.Info("Book is previewed");
        }

        /// <summary>
        /// Verify that image is placed or not placed on wanted field
        /// </summary>
        /// <param name="shouldImageBePlaced"> Boolean value representing if image should be placed on template or not, with default value of true </param>
        public static void VerifyImagePlacedOnTemplate(bool shouldImageBePlaced = true)
        {
            if(shouldImageBePlaced)
            {
                var randomPage = PagesList[ProjectHandler.ListOfAlreadyUsedPages[0]];
                randomPage.WaitForVisible();
                var imageField = randomPage.FindElement(By.CssSelector("div.place_image"));
                imageField.Displayed.Should().BeTrue((String)AssertionData.ImageNotPlaced);
            }
            else
            {
                AlertMsgBox.WaitForVisible();
                AlertMsgBox.Displayed.Should().BeTrue((String)AssertionData.ImageOnTextField);
            }
            log.Info("Image is not placed on wanted field");
        }

        /// <summary>
        /// The method verifies that show all images button displayes all images
        /// </summary>
        public static void VerifyUsageOfShowAllImagesButton()
        {
            List<string> ListOfNotDisplayedImages = new List<string>();
            ShowAllBtn.ClickWait();
            var numberOfImages = AllImages.Count;
            for(int i = 0; i < numberOfImages; i++)
            {
                try
                {
                    AllImages[i].Displayed.Should().BeTrue();
                }
                catch
                {
                    ListOfNotDisplayedImages.Add($"{i + 1}. image is not displayed");
                }
            }
            if (ListOfNotDisplayedImages.Count > 0)
            {
                ListOfNotDisplayedImages.ForEach(i => log.Error($"{i}"));
                ListOfNotDisplayedImages.Count.Equals(0).Should().BeTrue((String)AssertionData.ImagesDisplayed);
            }
            else
            {
                log.Info("All images are displayed");
            }
        }

        #endregion

        #region Get methods

        /// <summary>
        /// Get random book
        /// </summary> 
        /// <returns> Random book size enum </returns>
        private static Enum GetRandomBook()
        {
            var values = Enum.GetValues(typeof(SizesOfBook));
            var randomBookSize = values.GetValue(GetRandomNumber(values.Length - 1));
            return (SizesOfBook)(Enum)randomBookSize;
        }

        /// <summary>
        /// Returns book type of the current book
        /// </summary>
        /// <returns> Current book type </returns>
        public static string GetBookType()
        {
            var actualBookType = SizeOfBook.Text;
            var separatorIndex = 0;
            var counter = 0;

            foreach (var sign in actualBookType)
            {
                if (sign == ':') counter++;
                if (counter == 3) break;
                separatorIndex++;
            }
            actualBookType = actualBookType.Substring(separatorIndex + 2);

            separatorIndex = 0;
            foreach (var sign in actualBookType)
            {
                if ((sign == ',') || (sign == '(')) break;
                separatorIndex++;
            }
            actualBookType = actualBookType.Substring(0, separatorIndex);
            return actualBookType;
        }

        /// <summary>
        /// Method that returns currently opened Book size as a string
        /// </summary>
        /// <returns> Currently opened book size </returns>
        public static string GetBookSize()
        {
            var sizeOfBookString = SizeOfBook.Text;
            var firstSeparator = ": ";
            var secondSeparator = ",";
            var separatorIndex1 = sizeOfBookString.IndexOf(firstSeparator) + 2;
            var separatorIndex2 = sizeOfBookString.IndexOf(secondSeparator);
            var sizeOfBook = sizeOfBookString.Substring(separatorIndex1, separatorIndex2 - separatorIndex1);
            log.Info($"Current book size is: {sizeOfBook}");
            return sizeOfBook;
        }

        /// <summary>
        /// Get random text field
        /// </summary>
        /// <returns> Random text field </returns>
        private static IWebElement GetRandomTextField()
        {
            var numberOfTextFields = PagesWithTextField.Count;
            var randomField = GetRandomNumber(numberOfTextFields);
            var textField = PagesWithTextField[randomField];
            return textField;
        }

        /// <summary>
        /// Get random image field
        /// </summary>
        /// <returns> Random image field </returns>
        private static IWebElement GetRandomImageField()
        {
            var numberOfImageFields = PagesWithImageField.Count;
            var randomImageField = GetRandomNumber(numberOfImageFields);
            var imageField = PagesWithImageField[randomImageField];
            imageField.WaitForVisible();
            return imageField;
        }

        /// <summary>
        /// Get random image 
        /// </summary>
        /// <returns> Random image </returns>
        private static IWebElement GetRandomImage()
        {
            var numberOfImages = Images.Count;
            var randomImage = GetRandomNumber(numberOfImages);
            var image = Images[randomImage];
            return image;
        }

        /// <summary>
        /// Get random template 
        /// </summary>
        /// <param name="type"> Enum representing type of template, with default value of Random from TemplatesType enum </param>
        /// <returns> Random template </returns>
        private static IWebElement GetRandomTemplate(TemplatesType type = TemplatesType.Random)
        {
            int numberOfPageTemplates;
            int randomTemplate;
            IWebElement template;

            if (type == TemplatesType.WithTextField)
            {
                numberOfPageTemplates = TemplatesWithText.Count;
                randomTemplate = GetRandomNumber(numberOfPageTemplates);
                template = TemplatesWithText[randomTemplate];
                template.WaitForVisible();

            }
            else if (type == TemplatesType.WithImageField)
            {
                numberOfPageTemplates = TemplatesWithImage.Count;
                randomTemplate = GetRandomNumber(numberOfPageTemplates);
                template = TemplatesWithImage[randomTemplate];
                template.WaitForVisible();
            }
            else
            {
                numberOfPageTemplates = PageTemplatesList.Count;
                randomTemplate = GetRandomNumber(numberOfPageTemplates);
                template = PageTemplatesList[randomTemplate];
                template.WaitForVisible();
            }
            return template;
        }

        /// <summary>
        /// Get random page
        /// </summary>
        /// <returns> Random page </returns>
        private static IWebElement GetRandomPage()
        {
            var numberOfPages = PagesList.Count;
            int randomPage;
            while (true)
            {
                randomPage = GetRandomNumber(numberOfPages);
                if (!ProjectHandler.ListOfAlreadyUsedPages.Contains(randomPage)) break;
            }
            var page = PagesList[randomPage];
            ProjectHandler.ListOfAlreadyUsedPages.Add(randomPage);
            page.WaitForVisible();
            return page;
        }

        #endregion
    }
}
