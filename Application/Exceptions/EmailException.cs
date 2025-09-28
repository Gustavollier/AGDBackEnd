using System;

namespace Application.Exceptions;
public class EmailException : Exception
{
    public EmailException(string value):base(value){ }
}
