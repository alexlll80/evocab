namespace evocab.engine.Parsers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISentenceParser
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsEndOfText { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        void Init(string text);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetNext();
    }
}
