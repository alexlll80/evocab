namespace evocab.engine.Sentences.Models
{
    public struct SentenceBorder
    {
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }

        public bool IsEmpty() => EndPosition <= StartPosition;
    }
}
