    class SheetCollection : IReadOnlyCollection<int>
    {
        public int Count => throw new NotImplementedException();

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
