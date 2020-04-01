using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; } //2nd Content (parameter below) is this property
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //i.e. an anchor tag
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(Content); //1st Content is the text of the anchor tag
        }
    }
}
