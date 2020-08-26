﻿using Challenge.Application.UseCases.V1.Countries.Find;
using System;

namespace Challenge.Application.Tests.UseCases.V1.Find
{
    public sealed class Presenter :
        IOutputPort
    {
        public OutputData OutputData { get; private set; }

        public void NotFound(string message, object value)
        {
            throw new ArgumentOutOfRangeException("", value, message);
        }

        public void Success(OutputData outputData)
        {
            this.OutputData = outputData;
        }
    }
}
