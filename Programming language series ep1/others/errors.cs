using System;

namespace errors
{

    public struct ErrorType
    {
        public string ET;
        public ErrorType(string et)
        {
            ET = et;
        }
    }

    public class Error
    {
        public ErrorType ET;
        public string Reason;
        public Error(ErrorType et, string reason)
        {
            ET = et;
            Reason = reason;
        }
    }

    public struct RuntimeResult
    {
        public dynamic Result;
        public Error? Error;
        public RuntimeResult(dynamic result, Error? error)
        {
            Result = result;
            Error = error;
        }
    }

    public class SyntaxError : Error
    {
        public SyntaxError(string reason) : base(new ErrorType("SyntaxError"), reason) { }
    }
}