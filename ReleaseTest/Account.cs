using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace ReleaseTest
{
    [JsonConverter(typeof(AccountConverter))]
    public class Account : IAccount, IEquatable<Account>
    {
        public string Username { get; }
        public IImmutableList<District> Districts { get; }

        public Account(IAccount builder)
        {

            if (builder == null || String.IsNullOrWhiteSpace(builder?.Username))
            {
                throw new ArgumentNullException();
            }

            Username = builder.Username;
            Districts = builder.Districts ?? ImmutableList<District>.Empty;
        }

        public Account(JsonDto dto)
        {

            if (dto == null || String.IsNullOrWhiteSpace(dto?.Name))
            {
                throw new ArgumentNullException();
            }

            Username = dto.Name;
            Districts = dto.Districts ?? ImmutableList<District>.Empty;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Account);
        }

        public bool Equals(Account other)
        {
            return other != null &&
                Username.Equals(other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator ==(Account lhs, Account rhs)
        {
            return ReferenceEquals(lhs, rhs) ||
                (!ReferenceEquals(lhs, null) && !ReferenceEquals(rhs, null) && lhs.Equals(rhs));
        }

        public static bool operator !=(Account lhs, Account rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            throw new Exception("You should not be using hash codes of Account objects.");
        }

        /// <summary>
        /// Mutable version of Account.
        /// </summary>
        public class Builder : IAccount
        {
            public string Username { get; set; }

            public IImmutableList<District> Districts { get; set; }


            public void From(IAccount fromAcccount)
            {
                Username = fromAcccount.Username;
                Districts = fromAcccount.Districts;
            }
        }

        /// <summary>
        /// Provides JSON schema used by web api.
        /// </summary>
        public class JsonDto
        {
            public string Name { get; set; }
            public IImmutableList<District> Districts { get; set; }
        }
    }
}

