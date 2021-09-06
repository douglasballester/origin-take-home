﻿using Origin.Domain.Enums;

namespace Origin.Domain.Entities.PersonalInfo
{
    public class House
    {
        public OwnershipStatus OwnershipStatus { get; private set; }

        public House(OwnershipStatus ownershipStatus)
        {
            OwnershipStatus = ownershipStatus;
        }
    }
}
