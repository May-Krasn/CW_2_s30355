﻿namespace Kontenery_cw;

public class OverfillException : Exception
{
    public OverfillException() {}

    public OverfillException(string message) : base(message)
    {
    }

    public OverfillException(string message, string nrSeryjny) : base(message)
    {
    }

}