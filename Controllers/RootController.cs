using System;
using Microsoft.AspNetCore.Mvc;


namespace SquareRoot.Controllers
{
    public class RootController : Controller
    {
        [HttpGet]
        public ActionResult Square()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Square(string firstNumber, string secondNumber)
        {
            try{
                int numberOne = int.Parse(firstNumber);
                int numberTwo = int.Parse(secondNumber);
                string negative;
                string same;
                string higher;

                if (numberOne < 0 || numberTwo < 0){
                    negative = "Only positive numbers are allowed";
                    ViewBag.negative = negative;
                };

                if(numberOne == numberTwo){
                    same = "Please enter different numbers";
                    ViewBag.same = same;
                }
                double rootOne = Math.Sqrt(numberOne);
                double rootTwo = Math.Sqrt(numberTwo);

                if(rootTwo < rootOne){
                    higher = "The number " + numberOne + " with square root " + rootOne + " has a higher square root than the number " + numberTwo + " with square root " + rootTwo + ".";
                    ViewBag.higher = higher;
                };

                if(rootOne < rootTwo){
                    higher = "The number " + numberTwo + " with square root " + rootTwo + " has a higher square root than the number " + numberOne + " with square root " + rootOne + ".";
                    ViewBag.higher = higher;
                };
            }

            catch (ArgumentNullException) {
                string empty = "Please enter both fields";
                ViewBag.empty = empty;
            }

            catch (System.FormatException) {
                    string numbers = "Only integers are allowed";
                    ViewBag.numbers = numbers;
            }
            
            return View();
        }
    }
}
