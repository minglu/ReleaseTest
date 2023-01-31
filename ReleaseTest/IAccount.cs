using System;
using System.Collections.Immutable;

namespace ReleaseTest
{
    public interface IAccount
    {
        string Username { get; }

        IImmutableList<District> Districts { get; }
    }
}

