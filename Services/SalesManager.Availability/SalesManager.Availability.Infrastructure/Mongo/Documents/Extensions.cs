﻿using SalesManager.Availability.Application.DTO;
using SalesManager.Availability.Core.Entities;
using SalesManager.Availability.Core.ValueObjects;
using System;
using System.Linq;

namespace SalesManager.Availability.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static Resource AsEntity(this ResourceDocument document)
            => new Resource(document.Id, document.Tags, document.Reservations
                .Select(r => new Reservation(r.TimeStamp.AsDateTime(), r.Priority)), document.Version);

        public static ResourceDocument AsDocument(this Resource entity)
            => new ResourceDocument
            {
                Id = entity.Id,
                Version = entity.Version,
                Tags = entity.Tags,
                Reservations = entity.Reservations.Select(r => new ReservationDocument
                {
                    TimeStamp = r.DateTime.AsDaysSinceEpoch(),
                    Priority = r.Priority
                })
            };

        public static ResourceDto AsDto(this ResourceDocument document)
            => new ResourceDto
            {
                Id = document.Id,
                Tags = document.Tags ?? Enumerable.Empty<string>(),
                Reservations = document.Reservations?.Select(r => new ReservationDto
                {
                    DateTime = r.TimeStamp.AsDateTime(),
                    Priority = r.Priority
                }) ?? Enumerable.Empty<ReservationDto>()
            };

        internal static int AsDaysSinceEpoch(this DateTime dateTime)
            => (dateTime - new DateTime()).Days;

        internal static DateTime AsDateTime(this int daysSinceEpoch)
            => new DateTime().AddDays(daysSinceEpoch);
    }
}
