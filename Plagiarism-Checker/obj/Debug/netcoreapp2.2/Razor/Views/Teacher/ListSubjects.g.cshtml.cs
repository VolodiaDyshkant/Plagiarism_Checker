#pragma checksum "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad622a4e57a61220cd3c232300e7a705ecbe79c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_ListSubjects), @"mvc.1.0.view", @"/Views/Teacher/ListSubjects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Teacher/ListSubjects.cshtml", typeof(AspNetCore.Views_Teacher_ListSubjects))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\_ViewImports.cshtml"
using Plagiarism_Checker;

#line default
#line hidden
#line 2 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\_ViewImports.cshtml"
using Plagiarism_Checker.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad622a4e57a61220cd3c232300e7a705ecbe79c2", @"/Views/Teacher/ListSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4629291b9607b6f696e738bdc026a069f08427a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_ListSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Plagiarism_Checker.Models.Teacher.Subjects>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml"
  
    Layout = "~/Views/Shared/_TeacherLayout.cshtml";

#line default
#line hidden
            BeginContext(120, 158, true);
            WriteLiteral("\r\n<div class=\"largelightDiv\" style=\"margin: 1em;\r\n    padding: 1em;\r\n    display: list-item;\">\r\n    <h2 style=\"margin-bottom: 10px;\">Перелік дисциплін:</h2>\r\n");
            EndContext();
#line 11 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(319, 179, true);
            WriteLiteral("        <div style=\"width: 80%;\r\n    height: 180px;\r\n    margin-bottom: 20px;\r\n    border: none;\r\n    display: inline;\">\r\n            <p style=\"color: #000000; font-size: 15px;\"> ");
            EndContext();
            BeginContext(499, 21, false);
#line 18 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml"
                                                    Write(item.NameOfDiscipline);

#line default
#line hidden
            EndContext();
            BeginContext(520, 88, true);
            WriteLiteral(" </p>\r\n            <p style=\"color:#000000; font-size:15px; justify-content:flex-end;\"> ");
            EndContext();
            BeginContext(609, 10, false);
#line 19 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml"
                                                                            Write(item.Group);

#line default
#line hidden
            EndContext();
            BeginContext(619, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(623, 9, false);
#line 19 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml"
                                                                                          Write(item.Time);

#line default
#line hidden
            EndContext();
            BeginContext(632, 68, true);
            WriteLiteral(" </p>\r\n            <div style=\"clear:both;\"></div>\r\n        </div>\r\n");
            EndContext();
#line 22 "D:\3 курс\_Net\Plagiarism-Checker-Nataha\Plagiarism-Checker\Views\Teacher\ListSubjects.cshtml"
    }

#line default
#line hidden
            BeginContext(707, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Plagiarism_Checker.Models.Teacher.Subjects>> Html { get; private set; }
    }
}
#pragma warning restore 1591
