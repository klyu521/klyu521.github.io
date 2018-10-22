using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework4.Controllers
{
    public class ColorchooserController : Controller
    {
        // GET: Colorchooser
        
        public ActionResult Mix()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mix(string firstColor, string secondColor)
        {
           
            // Convert colors to Color object
            Color firstRgb = ColorTranslator.FromHtml(firstColor);
            Color secondRgb = ColorTranslator.FromHtml(secondColor);

            // Define red, grenn, blue to calcuate 
            int red = LimitValue(firstRgb.R, secondRgb.R);
            int green =LimitValue(firstRgb.G, secondRgb.G);
            int blue = LimitValue(firstRgb.B, secondRgb.B);

            // Use values to calculate the result
            Color newColor = Color.FromArgb(red, green, blue);
             string Result = ColorTranslator.ToHtml(newColor);

            // Use ViewBag with three colors
            ViewBag.ColorOne = "background:" + firstColor;
            ViewBag.ColorTwo = "background:" + secondColor;
            ViewBag.ColorThree = "background:" + Result;

            return View();
        }

        // The max value is 255
        private int LimitValue(int first, int second)
        {
           
            const int max = 255;

            // Add both colors and return that value if it's less than 255
            int value = first + second;
            if (value < max) return first + second;
            return max;
        }
    }
}