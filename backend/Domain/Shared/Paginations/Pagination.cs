namespace Domain.Shared.Paginations {
    public class Pagination<T> {
        public int Count { get; set; }
        public int Pages { get; set; }
        public bool Next { get; set; }
        public int Items { get; set; }
        public IEnumerable<T>? Results { get; set; }

            public Pagination(int count, int page, int length, IEnumerable<T> results) {
                this.Count = results.Count();
                this.Pages = (int)Math.Ceiling((double)count / (double)length);
                this.Next = (page * length) < count;
                this.Items = count;
                this.Results = results;
            }
    }
}