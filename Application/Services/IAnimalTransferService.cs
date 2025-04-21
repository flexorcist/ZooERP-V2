using System;
using Application.DTOs;

namespace Application.Services
{
    public interface IAnimalTransferService
    {
        void Transfer(TransferAnimalRequest request);
    }
}
