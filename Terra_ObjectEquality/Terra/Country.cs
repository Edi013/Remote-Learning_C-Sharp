using System;
using System.Diagnostics.CodeAnalysis;

namespace iQuest.Terra
{
    public class Country : IEquatable<Country>, IComparable<Country>
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }

        public bool Equals([AllowNull] Country other)
        {
            if (other == null) 
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            if (this.GetType() != other.GetType())
                return false;


            return this.Name == other.Name 
                && this.Capital == other.Capital
                ? true
                : false ;
        }
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType() 
                ? Equals(obj) 
                : false;
        }

        public int CompareTo([AllowNull] Country other)
        {
            if(other == null) return 1;
            if (ReferenceEquals(this, other)) return 0;

            var willReturn = Name.CompareTo(other.Name);
            if (willReturn != 0)
                return willReturn;

            return Capital.CompareTo(other.Capital);;
        
        }
        public int CompareTo(object obj)
        {
            if(this.GetType() != obj.GetType())
                throw new ArgumentException(nameof(obj));

            return CompareTo(obj as Country);
        }
    }
}