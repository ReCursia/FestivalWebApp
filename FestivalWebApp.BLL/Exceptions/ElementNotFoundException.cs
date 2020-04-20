using System;

namespace FestivalWebApp.BLL.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(object any)
        {
            Message = "Element " + any + " not found in database";
        }

        public override string Message { get; }
    }
}