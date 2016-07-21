using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Epi2._0.Models.Custom.Attributes
{
    /*
An annotation on any Episerver string property, which will restrict the editor from publishing the page as per the business rule intented, extend the scopt of property to any Episerver property
Author:Priti Jadhav
Purpose of the Class : This class can be used as validation attribute for any episerver text property
How to use:
1. Implement business logic to validate any proerty in IsValid() method
2. Provide error message in method FormatErrorMessage()
3. Use this class as a validation attribute for any text property
Points to take care: There are different parametorized methods of interface ValidationAttribute which we can implement in this class to 
achieve business requirement and can create paramentorized attribute
Highlight Risk : current implementation will only work for text property and not for other prop.

*/

    [AttributeUsage(AttributeTargets.Property)]
    public class ValidationProperty : ValidationAttribute
    {
        public ValidationProperty()
        {

        }

        public override bool IsValid(object value)
        {
            try
            {
                //Not Allowing Numbers
                char[] UnallowedCharacters = { '0', '1',
                                           '2', '3',
                                           '4', '5',
                                           '6', '7',
                                           '8', '9'};

                if (textContainsUnallowedCharacter(value.ToString(), UnallowedCharacters))
                {
                    FormatErrorMessage(value.ToString());
                    return false;
                }

            }

            catch (Exception) { }
            return true;

        }

        private bool textContainsUnallowedCharacter(string T, char[] UnallowedCharacters)
        {
            for (int i = 0; i < UnallowedCharacters.Length; i++)
                if (T.Contains(UnallowedCharacters[i]))
                    return true;

            return false;
        }





        public override string FormatErrorMessage(string name)
        {
            return name +" should not contain any numbers";
        }


    }
}