﻿using Challenge.Application.UseCases.V1.Countries.Get;

namespace Challenge.Application.Tests.UseCases.V1.Get
{
    public sealed class Presenter :
        IOutputPort
    {
        public OutputData OutputData { get; private set; }

        public void ExternalServiceError()
        {
            this.OutputData = null;
        }

        public void Success(OutputData outputData)
        {
            this.OutputData = outputData;
        }
    }
}
