using System;
using Google.Protobuf.WellKnownTypes;

// ReSharper disable once CheckNamespace
namespace Person
{
    // Properties for the underlying generated data from the proto file.
    // This partial class just adds extra properties for convenience.
    internal partial class PersonsDto
    {
        public DateTime Dob
        {
            get => DateOfBirth == null ? default(DateTime) : DateOfBirth.ToDateTime();
            set => DateOfBirth = Timestamp.FromDateTime(value.ToUniversalTime());
        }
    }
}