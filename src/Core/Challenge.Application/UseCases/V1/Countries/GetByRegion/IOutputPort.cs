﻿using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.GetByRegion
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortExternalServiceError,
        IOutputPortCancelled
    {

    }
}
