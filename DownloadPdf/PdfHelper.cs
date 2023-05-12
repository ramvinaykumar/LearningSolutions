//using Syncfusion.HtmlConverter;
//using Syncfusion.Pdf;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace DownloadPdf
//{
//    public class PdfHelper
//    {
//        public string DisplayIfGreaterTwentyOne(ref string htmlString, string htmlTag, int year, string previousLabel, string newLabel)
//        {
//            if (year >= 2022)
//            {
//                htmlString = htmlString.Replace(htmlTag, newLabel);
//            }
//            else
//            {
//                htmlString = htmlString.Replace(htmlTag, previousLabel);
//            }

//            return htmlString;
//        }

//        public void GeneratePdf()
//        {
//            //Initialize HTML to PDF converter. 
//            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

//            //Convert web forms to PDF interactive forms.
//            blinkConverterSettings.EnableForm = true;

//            //Assign Blink converter settings to HTML converter.
//            htmlConverter.ConverterSettings = blinkConverterSettings;

//            //Convert URL to PDF document. 
//            var filePath = Path.GetFullPath("ysoa.html");
//            PdfDocument document = htmlConverter.Convert(filePath);

//            //Create the filestream to save the PDF document. 
//            FileStream fileStream = new FileStream("HTML-to-PDF.pdf", FileMode.CreateNew, FileAccess.ReadWrite);

//            //Save and closes the PDF document.
//            document.Save(fileStream);
//            document.Close(true);
//        }

//        public string ReplaceFirst(string text, string search, string replace)
//        {
//            int pos = text.IndexOf(search);
//            if (pos < 0)
//            {
//                return text;
//            }
//            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
//        }

//        public string formatNumber(double amount)
//        {
//            return PDFHelper.FormatString(amount.ToString("0.00"), Utility.FormatSpecifier.NUMBER);
//        }


//        public String InflowAndOutflow(ref int seq, string htmlString, string cpfAccountNumber,   int year)
//        {
//            // 2.Inflow and outflow
//            // Set sequence number
//            // Inflow
//            double subseq = seq;
//            htmlString = this.ReplaceFirst(htmlString, "{seq}", seq.ToString());
//            seq = seq + 1;

//            var totalCreditAmount = 100;
//            var creditTotalFromSelf = 100;
//            var creditTotalFromEmployer = 100;
//            var creditTotalFromGovernment = 100;
//            var creditTotalOthersAmount = 100;

//            // donut chart 1                                                
//            var totalAmount = 100;

//            htmlString = htmlString
//                .Replace("{you}", this.formatNumber(creditTotalFromSelf));
//            htmlString = htmlString
//                .Replace("{employer}", this.formatNumber(creditTotalFromEmployer));
//            htmlString = htmlString
//                .Replace("{government}", this.formatNumber(creditTotalFromGovernment));

//            htmlString = htmlString
//                .Replace("{totalCreditAmount}", this.formatCurrency(totalCreditAmount));

//            // Hide if zero
//            DisplayIfGreaterTwentyOne(ref htmlString, "{otherFlowLabel}", year, "Other inflows", "Other inflow");
//            this.DisplayIfNotZero(ref htmlString, "{receivedTotal}", creditTotalOthersAmount, PDFConverterConstants.Regex.REGEX_PATTERN_P);

//            // Hide if zero
//            if (creditTotalOthersAmount == 0)
//            {
//                YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow.GROUP_CHART_FOOTNOTE);
//            }

//            // inflowChartSubLiner
//            htmlString = htmlString
//                   .Replace("{inflowyear}", year.ToString());

//            // Outflow
//            var totalDebitAmount = Math.Abs(digitalSOACreditDebitDto.TotalDebitAmount);
//            var debitTotalOthersAmount = Math.Abs(digitalSOACreditDebitDto.DebitTotalOthersAmount);

//            // these fields needed for chart to render
//            // donut chart 2
//            var housing = Math.Abs(digitalSOACreditDebitDto.DebitHousingAmount);
//            var retirement = Math.Abs(digitalSOACreditDebitDto.DebitRetirementAmount);
//            var healthcare = Math.Abs(digitalSOACreditDebitDto.DebitHealthcareAmount);
//            var others = debitTotalOthersAmount;

//            htmlString = htmlString
//                .Replace("{housing}", this.formatNumber(housing));
//            htmlString = htmlString
//                .Replace("{retirement}", this.formatNumber(retirement));
//            htmlString = htmlString
//                .Replace("{healthcare}", this.formatNumber(healthcare));
//            htmlString = htmlString
//                .Replace("{others}", this.formatNumber(others));


//            htmlString = htmlString
//                .Replace("{totalDebitAmount}", this.formatCurrency(totalDebitAmount));


//            var usedTotal = Math.Abs(totalDebitAmount);

//            // outflowChartLiner1
//            htmlString = htmlString
//                .Replace("{usedTotal}", this.formatCurrency(usedTotal));

//            // outflowChartSubLiner
//            htmlString = htmlString
//                   .Replace("{outflowyear}", year.ToString());


//            // 2.1 Inflow details
//            // CPF contributions by you
//            bool disableInflowDetails_1 = false;
//            bool disableInflowDetails_2 = false;
//            bool disableInflowDetails_3 = false;

//            subseq = subseq + 0.1;
//            htmlString = this.ReplaceFirst(htmlString, "{seq}", subseq.ToString("0.0"));

//            var creditSelfEECONAmount = digitalSOACreditDebitDto.CreditSelfEECONAmount;
//            var creditSelfEmpCONAmount = digitalSOACreditDebitDto.CreditSelfEmpCONAmount;
//            var creditSelfRSTUAmount = digitalSOACreditDebitDto.CreditSelfRSTUAmount;
//            var creditSelfVCAmount = digitalSOACreditDebitDto.CreditSelfVCAmount;

//            this.DisplayIfNotZero(ref htmlString, "{CPFContriByYou}", creditTotalFromSelf);
//            this.DisplayIfNotZero(ref htmlString, "{employeeContri}", creditSelfEECONAmount);
//            this.DisplayIfNotZero(ref htmlString, "{selfEmployedContri}", creditSelfEmpCONAmount);
//            this.DisplayIfNotZero(ref htmlString, "{retirementToppingUp}", creditSelfRSTUAmount);
//            this.DisplayIfNotZero(ref htmlString, "{voluntaryTopups}", creditSelfVCAmount);

//            // hide sub section
//            if (creditTotalFromSelf == 0 && creditSelfEECONAmount == 0 && creditSelfEmpCONAmount == 0 && creditSelfRSTUAmount == 0 && creditSelfVCAmount == 0)
//            {
//                disableInflowDetails_1 = true;
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_TR, PDFConverterConstants.InflowDetails.GROUP_CONTRIB_BY_YOU);
//            }
//            else
//            {
//                disableInflowDetails_1 = false;
//            }

//            // 2.1 Inflow details
//            // CPF contributions by your employer
//            //var creditTotalFromEmployer = digitalSOACreditDebitDto.CreditTotalFromEmployer;
//            var creditERCONAmount = digitalSOACreditDebitDto.CreditERCONAmount;
//            var creditERVCAmount = digitalSOACreditDebitDto.CreditERVCAmount;
//            var creditERCOCONAmount = digitalSOACreditDebitDto.CreditERCOCONAmount;

//            this.DisplayIfNotZero(ref htmlString, "{CPFContriByEmployer}", creditTotalFromEmployer);
//            this.DisplayIfNotZero(ref htmlString, "{employerContri}", creditERCONAmount);
//            this.DisplayIfNotZero(ref htmlString, "{voluntaryContri}", creditERVCAmount);
//            this.DisplayIfNotZero(ref htmlString, "{companyContri}", creditERCOCONAmount);

//            // hide sub section
//            if (creditTotalFromEmployer == 0 && creditERCONAmount == 0 && creditERVCAmount == 0 && creditERCOCONAmount == 0)
//            {
//                disableInflowDetails_2 = true;
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_TR, PDFConverterConstants.InflowDetails.GROUP_CONTRIB_BY_EMPLOYER);
//            }
//            else
//            {
//                disableInflowDetails_2 = false;
//            }


//            // 2.1 Inflow details
//            // CPF contributions by the Government
//            this.DisplayIfNotZero(ref htmlString, "{CPFContriBygovernment}", creditTotalFromGovernment);

//            var creditGovtBIAmount = digitalSOACreditDebitDto.CreditGovtBIAmount;
//            var creditGovtEIAmount = digitalSOACreditDebitDto.CreditGovtEIAmount;
//            var creditGovtTIAmount = digitalSOACreditDebitDto.CreditGovtTIAmount;

//            // if return value of 0, do not display
//            this.DisplayIfNotZero(ref htmlString, "{baseInterest}", creditGovtBIAmount);

//            // if return value of 0, do not display
//            this.DisplayIfNotZero(ref htmlString, "{extraInterest}", creditGovtEIAmount);

//            // if return value of 0, do not display
//            if (creditGovtBIAmount == 0 && creditGovtEIAmount == 0)
//            {
//                this.DisplayIfNotZero(ref htmlString, "{totalInterest}", creditGovtTIAmount);
//            }
//            else
//            {
//                disableInflowDetails_3 = false;
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_TR, "totalInterest");
//            }

//            var creditGovtOtherSupportAmount = digitalSOACreditDebitDto.CreditGovtOtherSupportAmount;

//            this.DisplayIfNotZero(ref htmlString, "{governmentSupport}", creditGovtOtherSupportAmount);

//            var creditGovtOTHCSSPAmount = digitalSOACreditDebitDto.CreditGovtOTHCSSPAmount;
//            var creditGovtOTHCAYEMMCSAmount = digitalSOACreditDebitDto.CreditGovtOTHCAYEMMCSAmount;
//            var creditGovtOTHCLBAmount = digitalSOACreditDebitDto.CreditGovtOTHCLBAmount;
//            var creditGovtOTHBCTAmount = digitalSOACreditDebitDto.CreditGovtOTHBCTAmount;

//            // Assurance Package
//            var creditGovtOTHAPAmount = digitalSOACreditDebitDto.CreditGovtOTHAPAmount;
//            DisplayIfGreaterTwentyOne(ref htmlString, "{assurancePackageDisplayMode}", year, "display:none;", "display: table-row;");
//            this.DisplayIfNotZero(ref htmlString, "{assurancePackage}", creditGovtOTHAPAmount);

//            this.DisplayIfNotZero(ref htmlString, "{careAndSupport}", creditGovtOTHCSSPAmount);
//            this.DisplayIfNotZero(ref htmlString, "{CAYEMatchedMedisaveContri}", creditGovtOTHCAYEMMCSAmount);
//            this.DisplayIfNotZero(ref htmlString, "{CPFLifeBonus}", creditGovtOTHCLBAmount);
//            this.DisplayIfNotZero(ref htmlString, "{CPFTopup}", creditGovtOTHBCTAmount);
//            var creditGovtOTHDVBAmount = digitalSOACreditDebitDto.CreditGovtOTHDVBAmount;
//            var creditGovtOTHPSEAAmount = digitalSOACreditDebitDto.CreditGovtOTHPSEAAmount;
//            var creditGovtOTHGSTVAmount = digitalSOACreditDebitDto.CreditGovtOTHGSTVAmount;
//            var creditGovtOTHHGAmount = digitalSOACreditDebitDto.CreditGovtOTHHGAmount;
//            var creditGovtOTHMGNAmount = digitalSOACreditDebitDto.CreditGovtOTHMGNAmount;

//            this.DisplayIfNotZero(ref htmlString, "{defermentBonus}", creditGovtOTHDVBAmount);

//            // GovCash
//            var creditGovtOTHGCAmount = digitalSOACreditDebitDto.CreditGovtOTHGCAmount;
//            DisplayIfGreaterTwentyOne(ref htmlString, "{wbbDisplayMode}", year, "display:none;", "display: table-row;");
//            this.DisplayIfNotZero(ref htmlString, "{govCash}", creditGovtOTHGCAmount);

//            this.DisplayIfNotZero(ref htmlString, "{edusaveTransfer}", creditGovtOTHPSEAAmount);
//            this.DisplayIfNotZero(ref htmlString, "{gstVoucher}", creditGovtOTHGSTVAmount);
//            this.DisplayIfNotZero(ref htmlString, "{housingGrant}", creditGovtOTHHGAmount);

//            // Matched Retirement Savings Scheme Grant
//            var creditGovtOTHMRSAmount = digitalSOACreditDebitDto.CreditGovtOTHMRSAmount;
//            DisplayIfGreaterTwentyOne(ref htmlString, "{matchedRetirementSavingsSchemeGrantDisplayMode}", year, "display:none;", "display: table-row;");
//            this.DisplayIfNotZero(ref htmlString, "{matchedRetirementSavings}", creditGovtOTHMRSAmount);

//            this.DisplayIfNotZero(ref htmlString, "{medisaveForNewborns}", creditGovtOTHMGNAmount);

//            var creditGovtOTHMGAmount = digitalSOACreditDebitDto.CreditGovtOTHMGAmount;
//            var creditGovtOTHNSAmount = digitalSOACreditDebitDto.CreditGovtOTHNSAmount;
//            var creditGovtOTHORNSAmount = digitalSOACreditDebitDto.CreditGovtOTHORNSAmount;
//            var creditGovtOTHPGAmount = digitalSOACreditDebitDto.CreditGovtOTHPGAmount;
//            var creditGovtOTHSIRSAmount = digitalSOACreditDebitDto.CreditGovtOTHSIRSAmount;

//            this.DisplayIfNotZero(ref htmlString, "{merdekaGenMedisave}", creditGovtOTHMGAmount);
//            this.DisplayIfNotZero(ref htmlString, "{NSHomeAwards}", creditGovtOTHNSAmount);
//            this.DisplayIfNotZero(ref htmlString, "{ORNSCompletionAward}", creditGovtOTHORNSAmount);
//            this.DisplayIfNotZero(ref htmlString, "{pioneerGenMedisave}", creditGovtOTHPGAmount);
//            this.DisplayIfNotZero(ref htmlString, "{SEPIncomeRelief}", creditGovtOTHSIRSAmount);

//            var creditGovtOTHSGBAmount = digitalSOACreditDebitDto.CreditGovtOTHSGBAmount;
//            var creditGovtOTHSSSAmount = digitalSOACreditDebitDto.CreditGovtOTHSSSAmount;
//            var creditGovtOTHWISAmount = digitalSOACreditDebitDto.CreditGovtOTHWISAmount;
//            var creditGovtOTHMTS5Amount = digitalSOACreditDebitDto.CreditGovtOTHMTS5Amount;

//            this.DisplayIfNotZero(ref htmlString, "{SGBonus2018}", creditGovtOTHSGBAmount);
//            this.DisplayIfNotZero(ref htmlString, "{govSupportSilverSupport}", creditGovtOTHSSSAmount);
//            this.DisplayIfNotZero(ref htmlString, "{workfare}", creditGovtOTHWISAmount);
//            this.DisplayIfNotZero(ref htmlString, "{fiveYearMedisaveTopup}", creditGovtOTHMTS5Amount);

//            if (creditTotalFromGovernment == 0)
//            {
//                disableInflowDetails_3 = true;
//            }

//            if (disableInflowDetails_1)
//            {
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_TR, PDFConverterConstants.InflowDetails.GROUP_CONTRIB_BY_YOU);
//            }

//            if (disableInflowDetails_2)
//            {
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_TR, PDFConverterConstants.InflowDetails.GROUP_CONTRIB_BY_EMPLOYER);
//            }

//            if (disableInflowDetails_3)
//            {
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_TR, PDFConverterConstants.InflowDetails.GROUP_CONTRIB_BY_GOV);
//            }

//            if (disableInflowDetails_1 && disableInflowDetails_2 && disableInflowDetails_3)
//            {
//                subseq = subseq - 0.1;

//                // Disable entire section            
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_INFLOW_DETAILS);
//            }


//            // 2.2
//            // Other inflow details                        
//            subseq = subseq + 0.1;
//            htmlString = this.ReplaceFirst(htmlString, "{seq}", subseq.ToString("0.0"));

//            var creditOthersADJAmount = digitalSOACreditDebitDto.CreditOthersADJAmount;
//            var creditRefundDPSAmount = digitalSOACreditDebitDto.CreditRefundDPSAmount;
//            var creditRefundEDNAmount = digitalSOACreditDebitDto.CreditRefundEDNAmount;

//            // Other CPF inflows
//            DisplayIfGreaterTwentyOne(ref htmlString, "{otherCPFInflowLabel}", year, "Other CPF inflows in " + year, "Other CPF inflow in " + year);
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{otherCPFInflows}", creditTotalOthersAmount);

//            // Adjustments  
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{inflowAdjustments}", digitalSOACreditDebitDto.CreditOthersADJAmount);

//            // Dependant's Protection Scheme refund 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{depProtectionSchemeRefund}", digitalSOACreditDebitDto.CreditRefundDPSAmount);

//            // Education Scheme refund
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{educSchemeRefund}", digitalSOACreditDebitDto.CreditRefundEDNAmount);

//            // Healthcare Scheme refund 
//            DisplayIfGreaterTwentyOne(ref htmlString, "{wbbDisplayModeHealthcare}", year, "display: table-row;", "display: none;");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{HCSchemeRefund}", digitalSOACreditDebitDto.CreditRefundHCAmount);

//            // Home Protection Scheme claim
//            DisplayIfGreaterTwentyOne(ref htmlString, "{homeProtectSchemeClaimLabel}", year, "Home Protection Scheme refund", "Home Protection Scheme claim");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{homeProtectSchemeClaim}", digitalSOACreditDebitDto.CreditOthersHPCAmount);

//            // Home Protection Scheme rebate 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{homeProtectSchemeRebate}", digitalSOACreditDebitDto.CreditOthersHPRAmount);

//            // Housing  Scheme refund
//            DisplayIfGreaterTwentyOne(ref htmlString, "{wbbDisplayModeHousing}", year, "display: table-row;", "display: none;");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{housingSchemeRefund}", digitalSOACreditDebitDto.CreditRefundHSAmount);

//            // Investment Scheme refund 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{investmentSchemeRefund}", digitalSOACreditDebitDto.CreditRefundINVAmount);

//            // Other credits 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{otherCredits}", digitalSOACreditDebitDto.CreditOthersOTHAmount);

//            // Refund for Healthcare - 2022
//            DisplayIfGreaterTwentyOne(ref htmlString, "{healthcareWbbDisplayMode}", year, "display:none;", "display: table-row;");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{HCSchemeRefund}", digitalSOACreditDebitDto.CreditRefundHCAmount);

//            // Refund for Housing - 2022
//            DisplayIfGreaterTwentyOne(ref htmlString, "{housingWbbDisplayMode}", year, "display:none;", "display: table-row;");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{housingSchemeRefund}", digitalSOACreditDebitDto.CreditRefundHSAmount);

//            // Refund for Retirement - 2022
//            DisplayIfGreaterTwentyOne(ref htmlString, "{retirementWbbDisplayMode}", year, "display:none;", "display: table-row;");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{retirementSchemeRefund}", digitalSOACreditDebitDto.CreditRefundRAAmount);

//            // Refund of withdrawn CPF savings 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{refundOfWithdrawnCPFSavings}", digitalSOACreditDebitDto.CreditRefundWDLAmount);

//            // Retirement Scheme refund
//            DisplayIfGreaterTwentyOne(ref htmlString, "{wbbDisplayModeRetirement}", year, "display: table-row;", "display: none;");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{retirementSchemeRefund}", digitalSOACreditDebitDto.CreditRefundRAAmount);

//            // Special Discounted Shares
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{specialDiscountedShares}", digitalSOACreditDebitDto.CreditRefundSDSAmount);

//            // Transfers from other CPF accounts
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{transferFromOtherCPF}", digitalSOACreditDebitDto.CreditOthersTFRAmount);

//            // Transfers within your CPF accounts (including adjustments)
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{transfersWithinCPFWithAdjustments}", digitalSOACreditDebitDto.CreditOthersINTRAAmount);

//            if (totalCreditAmount > 0)
//            {
//                // Hide summary liner 2
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_DONUT_INFLOW_LINER_2);
//            }
//            else
//            if (totalCreditAmount == 0)
//            {
//                // Hide inflow donut chart using css
//                htmlString = Regex.Replace(htmlString, "div class=\"chartContainer mb-20\" id=\"getChartInflow\"",
//                                                       "div class=\"chartContainer mb-20 d-none\" id=\"getChartInflow\"",
//                                                        RegexOptions.Multiline);

//                // Hide Summary liner
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_DONUT_INFLOW_LINER_1);

//                // Hide summary liner 2
//                //htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_DONUT_INFLOW_LINER_2);

//                if (creditTotalOthersAmount == 0)
//                // Scenario 3
//                {
//                    // Show summary liner 2 and subliner
//                    // Hide liner 1
//                    htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_DONUT_INFLOW_LINER_1);

//                    // Hide Other Inflow
//                    htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_INFLOW_FOOTNOTE);
//                }
//            }

//            // Outflow
//            // Scenario 1: if TotalDebitAmount > 0
//            if (Math.Abs(totalDebitAmount) > 0)
//            {
//                // Disable summary liner 2
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Outflow.GROUP_CHART_LINER_2);

//            }
//            else
//            // Scenario 2: if TotalDebitAmount = 0
//            if (totalDebitAmount == 0)
//            {
//                // Hide outflow donut chart using css                
//                htmlString = Regex.Replace(htmlString, "div class=\"chartContainer\" id=\"getChartOutFlow\"",
//                                                       "div class=\"chartContainer d-none\" id=\"getChartOutFlow\"",
//                                                       RegexOptions.Multiline);



//                // Hide summary liner 1
//                htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Outflow.GROUP_CHART_LINER_1);

//                // do not hide this
//                //// Hide subliner
//                //htmlString = YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Outflow.GROUP_CHART_SUB_LINER);
//            }

//            // Hide 2.2 - Hide section when total other inflow = 0 
//            if (creditTotalOthersAmount == 0)
//            {
//                subseq = subseq - 0.1;
//                YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_OTHER_INFLOW_DETAILS);
//            }

//            // 2.3 Other outflow details
//            // CreditTotalOthersAmount
//            subseq = subseq + 0.1;
//            htmlString = this.ReplaceFirst(htmlString, "{seq}", subseq.ToString("0.0"));

//            // Other CPF outflows
//            htmlString = this.DisplayIfGreaterTwentyOne(ref htmlString, "{otherCPFOutflowsLabel}", year, "Other CPF outflows in " + year, "Other CPF outflow in " + year);
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{otherCPFOutflows}", Math.Abs(debitTotalOthersAmount));

//            // Adjustments  
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{outflowAdjustments}", Math.Abs(digitalSOACreditDebitDto.DebitOthersADJAmount));

//            // CPF Education Loan Scheme transactions 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{CPFEducSchemeTrans}", Math.Abs(digitalSOACreditDebitDto.DebitOthersEDNAmount));

//            // CPF Investment Scheme transactions 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{CPFInvSchemeTrans}", Math.Abs(digitalSOACreditDebitDto.DebitOthersINVAmount));

//            // Dependants' Protection Scheme
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{DepProtectionSchemePremium}", Math.Abs(digitalSOACreditDebitDto.DebitOthersDPSAmount));

//            // Other debits   
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{otherDebits}", Math.Abs(digitalSOACreditDebitDto.DebitOthersOTHAmount));

//            // Return of CPF LIFE bonus  
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{CPFLIFEBonusReturn}", Math.Abs(digitalSOACreditDebitDto.DebitOthersLISAmount));

//            // Reversal of Home Protection Scheme claim 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{HomeProtectonSchemeClaimReversal}", Math.Abs(digitalSOACreditDebitDto.DebitOthersHPSAmount));

//            // Transfers to other CPF 
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{transferToOtherCPF}", Math.Abs(digitalSOACreditDebitDto.DebitOthersTFRAmount));

//            // Transfers within your CPF accounts
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{transferwithinCPFWithAdjustments}", Math.Abs(digitalSOACreditDebitDto.DebitOthersINTRAAmount));

//            // Withdrawal from balance of housing refund
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{housingBalRefundWithdrawal}", Math.Abs(digitalSOACreditDebitDto.DebitOthersHRFAmount));

//            //	Withdrawal on reduced life expectancy
//            htmlString = this.DisplayIfGreaterTwentyOne(ref htmlString, "{medicalGroundsWithdrawalLabel}", year, "Withdrawal of CPF savings on reduced life expectancy (medical grounds)", "Withdrawal of CPF savings on reduced life expectancy");
//            htmlString = this.DisplayIfNotZero(ref htmlString, "{medicalGroundsWithdrawal}", Math.Abs(digitalSOACreditDebitDto.DebitOthersRLEAmount));


//            // Hide 2.3 - Hide section when total other outflow = 0
//            if (debitTotalOthersAmount == 0)
//            {
//                subseq = subseq - 0.1;
//                YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_OTHER_OUTFLOW_DETAILS);
//            }

//            // Hide page break if no inflow outflow
//            if (creditTotalOthersAmount == 0 && debitTotalOthersAmount == 0)
//            {
//                //YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.Inflow_Outflow.GROUP_PAGE_BREAK);
//            }


//            // 2.4 Supporting Your Golden Years
//            // LifeFinancialTipTemplate > RssFinancialTipTemplate
//            subseq = subseq + 0.1;

//            var lifeFinancialTipTemplate = string.Empty;
//            var rssFinancialTipTemplate = string.Empty;

//            if (financialTip != null)
//            {
//                lifeFinancialTipTemplate = financialTip.LifeFinancialTipTemplate;
//                rssFinancialTipTemplate = financialTip.RssFinancialTipTemplate;
//            }

//            var listFootnotesLife = new List<string>();
//            var listFootnotesRSS = new List<string>();

//            // Scenario 1: Supporting Your Golden Years (LIFE Template)
//            if (!string.IsNullOrEmpty(lifeFinancialTipTemplate))
//            {
//                this.getFootnoteSupportingYourGoldenYears(ref htmlString, cpfAccountNumber, ref listFootnotesLife, financialTip);

//                // Hide retirement                
//                YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.GoldenYearsRSS.GROUP_RETIREMENT_SUPPORT);

//                htmlString = this.ReplaceFirst(htmlString, "{seq}", subseq.ToString("0.0"));
//            }
//            else
//            if (!string.IsNullOrEmpty(rssFinancialTipTemplate))
//            // Scenario 2: Supporting Your Retirement (RSS Message templates)
//            {
//                this.getFootnoteSupportingYourRetirement(ref htmlString, cpfAccountNumber, ref listFootnotesRSS, financialTip);

//                // Hide goldenYearSupport
//                YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.GoldenYearsRSS.GROUP_GOLDEN_YEAR_SUPPORT);

//                htmlString = this.ReplaceFirst(htmlString, "{seq}", subseq.ToString("0.0"));
//            }

//            // If both tips are empty OR no footnotes
//            if ((string.IsNullOrEmpty(lifeFinancialTipTemplate) && string.IsNullOrEmpty(rssFinancialTipTemplate)) ||
//                (listFootnotesLife.Count == 0 && listFootnotesRSS.Count == 0))
//            {
//                removeFootnotesLifeAndGoldenYears(ref htmlString);
//            }

//            return htmlString;
//        }

//        public string removeFootnotesLifeAndGoldenYears(ref string htmlString)
//        {
//            // Hide retirement                
//            YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.GoldenYearsRSS.GROUP_RETIREMENT_SUPPORT);

//            // Hide goldenYearSupport
//            YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.GoldenYearsRSS.GROUP_GOLDEN_YEAR_SUPPORT);

//            // Hide outer group
//            YSOAPDFServiceBase.removeBlock(ref htmlString, PDFConverterConstants.Regex.REGEX_PATTERN_GROUP, PDFConverterConstants.GoldenYearsRSS.GROUP_OUTER);

//            return htmlString;
//        }

//        public string getFootnoteSupportingYourRetirement(ref string htmlString, string cpfAccountNumber, ref List<string> listFootnotes, DigitalSOAFinancialTipDto financialTip)
//        {
//            string subliner = string.Empty;
//            listFootnotes = new List<string>();

//            var rssRABalanceAmount = financialTip.RssRABalanceAmount;
//            var rssMonthlyPayoutAmount = financialTip.RssMonthlyPayoutAmount;
//            var rssPEA = financialTip.RssPEA;

//            // Template 4A – RSS members below PEA or placed on CPF LIFE
//            if (rssMembersBelowPEAOrPlacedOnCPFLife(financialTip))
//            {
//                subliner = string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_SUBLINER_4A, this.formatCurrency(rssRABalanceAmount));

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_FOOTNOTE_4A, rssPEA));
//            }
//            else
//            // Template 4B(i) – RSS members above PEA, 70 & above, and not receiving payouts [For RssPEATag=N, RssDPSATag=N] 
//            if (rssSMembersAbovePEABelow70AndNotReceivingPayouts(financialTip))
//            {
//                subliner = string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_SUBLINER_4B_I, this.formatCurrency(rssRABalanceAmount));

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_FOOTNOTE_4B_I));
//            }
//            else
//            // Template 4B(ii) – RSS members above PEA, below 70, and not receiving [For RssPEATag=N, RssDPSATag=Y] 
//            if (rssSMembersAbovePEAAbove70AndNotReceivingPayouts(financialTip))
//            {
//                subliner = string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_SUBLINER_4B_II, this.formatCurrency(rssRABalanceAmount));

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_FOOTNOTE_4B_II));
//            }
//            else
//            // Template 5 – RSS members above PEA and receiving payouts
//            if (rssMembersAbovePEAAndReceivingPayouts(financialTip))
//            {
//                subliner = string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_SUBLINER_5, this.formatCurrency(rssRABalanceAmount));

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteSupportingYourRetirement.TEMPLATE_FOOTNOTE_5, this.formatCurrency(rssMonthlyPayoutAmount)));
//            }
//            else
//            // Template 6 – Member does not receive RSS or CPF LIFE advisory
//            if (memberDoesNotReceiveRSSOrCPFLifeAdvisory(financialTip))
//            {
//                return htmlString;
//            }

//            htmlString = htmlString
//                .Replace("{subTitleSupportingYourRetirement}", subliner);

//            if (listFootnotes != null && listFootnotes.Count > 0)
//            {
//                htmlString = this.formRepeatGroup(ref htmlString, listFootnotes, "getFootNoteRetirementSupport", "{messageRetirementSupport}");
//            }

//            return htmlString;
//        }

//        // Template 4A – RSS members below PEA or placed on CPF LIFE
//        public bool rssMembersBelowPEAOrPlacedOnCPFLife(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.RssFinancialTipTemplate == "4" && financialTip.RssPEATag == true;
//        }

//        // Template 4B(i) – RSS members above PEA, below 70 and not receiving payouts [For RssPEATag=N, RssDPSATag=N] 
//        public bool rssSMembersAbovePEABelow70AndNotReceivingPayouts(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.RssFinancialTipTemplate == "4" && financialTip.RssPEATag == false && financialTip.RssDPSATag == false;
//        }

//        // Template 4B(ii) – RSS members above PEA, 70 & above and not receiving payout [For RssPEATag=N, RssDPSATag=Y] 
//        public bool rssSMembersAbovePEAAbove70AndNotReceivingPayouts(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.RssFinancialTipTemplate == "4" && financialTip.RssPEATag == false && financialTip.RssDPSATag == true;
//        }

//        // Template 5 – RSS members above PEA and receiving payouts
//        public bool rssMembersAbovePEAAndReceivingPayouts(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.RssFinancialTipTemplate == "5";
//        }

//        // Template 6 – Member does not receive RSS or CPF LIFE advisory
//        public bool memberDoesNotReceiveRSSOrCPFLifeAdvisory(DigitalSOAFinancialTipDto financialTip)
//        {
//            return memberDoesNotReceiveRSSAdvisory(financialTip) && memberDoesNotReceiveCPFLifeAdvisory(financialTip);
//        }

//        public bool memberDoesNotReceiveRSSAdvisory(DigitalSOAFinancialTipDto financialTip)
//        {
//            return string.IsNullOrEmpty(financialTip.RssFinancialTipTemplate);
//        }

//        public bool memberDoesNotReceiveCPFLifeAdvisory(DigitalSOAFinancialTipDto financialTip)
//        {
//            return string.IsNullOrEmpty(financialTip.LifeFinancialTipTemplate);
//        }

//        private string getFootnoteSupportingYourGoldenYears(ref string htmlString, string cpfAccountNumber, ref List<string> listFootnotes, DigitalSOAFinancialTipDto financialTip)
//        {
//            listFootnotes = new List<string>();

//            var lifePEA = financialTip.LifePEA;
//            var lifeProjectedPayoutsMinAmount = financialTip.LifeProjectedPayoutsMinAmount;
//            var lifeProjectedPayoutsMaxAmount = financialTip.LifeProjectedPayoutsMaxAmount;
//            var lifeCPFLIFEPlanDescription = financialTip.LifeCPFLIFEPlanDescription;
//            var lifeProjectedPayoutsDefaultAmount = financialTip.LifeProjectedPayoutsDefaultAmount;
//            var lifePayoutReceivedResumptionDate = financialTip.LifePayoutReceivedResumptionDate;

//            // 2C
//            var lifePayoutNotReceivedResumptionDate = financialTip.LifePayoutNotReceivedResumptionDate;

//            var lifeTotalRetirementPayoutsReceivedToDate = financialTip.LifeTotalRetirementPayoutsReceivedToDate;
//            var lifeActualMonthlyPayoutsAmount = financialTip.LifeActualMonthlyPayoutsAmount;

//            // "From age XX <PEA age> (LifePEA), you will receive an estimated monthly retirement payout of $XXX (LifeProjectedPayoutsMinAmount) - $YYY (LifeProjectedPayoutsMaxAmount)."
//            string subliner = string.Empty;

//            // Template 2A
//            if (isCPFLIFEMemberBelowPEA2Months(financialTip) && isPayout100AndAbove(financialTip))
//            {
//                string footNote1 = string.Empty;
//                string footNote2 = string.Empty;
//                subliner = this.getMessageSupportingYourGoldenYears(lifeCPFLIFEPlanDescription);

//                // Template 2A(a) – CPF LIFE Member below PEA – 2 months and payout $100 and above, and payout has a range.
//                if (payoutHasRange(financialTip))
//                    listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_2A_1_A, lifePEA, this.formatCurrency(lifeProjectedPayoutsMinAmount), this.formatCurrency(lifeProjectedPayoutsMaxAmount)));
//                else
//                if (payoutRangeSameValue(financialTip))
//                    // Template 2A(b) – CPF LIFE Member below PEA – 2 months and payout $100 and above, and payout range is of same value.
//                    listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_2A_1_B, lifePEA, this.formatCurrency(lifeProjectedPayoutsMinAmount)));

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_2A_2));
//            }
//            else
//            // Template 2B – CPF LIFE Member PEA – 2 months and above but below PEA & payout is $100 and above
//            if (this.isCPFLIFEMemberPEA2MonthsAndAboveButBelowPEA(financialTip))
//            {
//                subliner = this.getMessageSupportingYourGoldenYears(lifeCPFLIFEPlanDescription);

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_2B, lifePEA, this.formatCurrency(lifeProjectedPayoutsDefaultAmount)));
//            }
//            else
//            // Template 2C – CPF LIFE Members who have deferred and yet to receive payouts
//            if (this.isCPFLifeMemberWhoHasDeferredAndYetToReceivePayouts(financialTip))
//            {
//                subliner = this.getMessageSupportingYourGoldenYears(lifeCPFLIFEPlanDescription);

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_2C, lifePayoutNotReceivedResumptionDate.DateTime.ToString("MMM yyyy")));
//            }
//            else
//            // Template 3A – CPF LIFE Members above PEA and receiving payouts of $100 and above
//            if (this.isCPFLIFEMemberAbovePEA(financialTip))
//            {
//                subliner = this.getMessageSupportingYourGoldenYears(lifeCPFLIFEPlanDescription);

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_3A_1, this.formatCurrency(lifeActualMonthlyPayoutsAmount)));
//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_3A_2, this.formatCurrency(lifeTotalRetirementPayoutsReceivedToDate)));
//            }
//            else
//            // Template 3B – CPF LIFE Members who have deferred and have received payouts
//            if (this.isCPFLifeMemberWhoHasDeferredAndReceivedPayouts(financialTip))
//            {
//                subliner = this.getMessageSupportingYourGoldenYears(lifeCPFLIFEPlanDescription);

//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_3B_1, lifePayoutReceivedResumptionDate.DateTime.ToString("MMM yyyy")));
//                listFootnotes.Add(string.Format(PDFConverterConstants.FootnoteGoldenYears.TEMPLATE_3B_2, this.formatCurrency(lifeTotalRetirementPayoutsReceivedToDate)));
//            }

//            htmlString = htmlString
//                .Replace("{subTitleSupportingYourGoldenYears}", subliner);

//            htmlString = this.formRepeatGroup(ref htmlString, listFootnotes, "getFootNoteGoldenYearSupport", "{messageSupportingYourGoldenYears}");

//            return htmlString;
//        }

//        // Template 2A
//        public bool isCPFLIFEMemberBelowPEA2Months(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeFinancialTipTemplate == "2A";
//        }

//        // Template 2B – CPF LIFE Member PEA – 2 months and above but below PEA & payout is $100 and above
//        public bool isCPFLIFEMemberPEA2MonthsAndAboveButBelowPEA(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeFinancialTipTemplate == "2B";
//        }

//        // Template 2C – CPF LIFE Members who have deferred and yet to receive payouts
//        public bool isCPFLifeMemberWhoHasDeferredAndYetToReceivePayouts(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeFinancialTipTemplate == "2C";
//        }

//        // Template 3A – CPF LIFE Members above PEA and receiving payouts of $100 and above
//        public bool isCPFLIFEMemberAbovePEA(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeFinancialTipTemplate == "3A";
//        }

//        // Template 3B – CPF LIFE Members who have deferred and have received payouts
//        public bool isCPFLifeMemberWhoHasDeferredAndReceivedPayouts(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeFinancialTipTemplate == "3B";
//        }

//        public bool isPayout100AndAbove(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeProjectedPayoutsMaxAmount > 100;
//        }

//        public bool payoutHasRange(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeProjectedPayoutsMaxAmount > financialTip.LifeProjectedPayoutsMinAmount;
//        }

//        public bool payoutRangeSameValue(DigitalSOAFinancialTipDto financialTip)
//        {
//            return financialTip.LifeProjectedPayoutsMaxAmount == financialTip.LifeProjectedPayoutsMinAmount;
//        }

//        private string getMessageSupportingYourGoldenYears(string lifeCPFLIFEPlanDescription)
//        {
//            return string.Format("You are on CPF LIFE {0}", lifeCPFLIFEPlanDescription);
//        }
//    }
//}
