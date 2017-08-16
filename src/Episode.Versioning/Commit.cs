using System;

namespace Episode.Versioning
{
    public struct Commit
    {
        public static readonly Commit Any = new Commit(-1);

        private long _major;
        private long _minor;

        private Commit(int any)
        {
            _major = -1;
            _minor = -1;
        }

        public Commit(long major, long minor)
        {
            if (major < 0) throw new Exception($"{nameof(major)} must be greater than or equal to 0.");
            if (minor < 0) throw new Exception($"{nameof(minor)} must be greater than or equal to 0.");

            _major = major;
            _minor = minor;
        }

        public override bool Equals(object obj) => obj is Commit c ? c._major == _major && c._minor == _minor : false;

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + _major.GetHashCode();
                hash = hash * 23 + _minor.GetHashCode();

                return hash;
            }
        }

        public override string ToString() => $"{_major}.{_minor}";

        public bool IsAtLeast(Commit commit)
        {
            return _major > commit._major || (_major == commit._major && _minor >= commit._minor);
        }
    }
}
