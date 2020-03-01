namespace SnapUsernameChecker
{
    public struct SnapResult
    {
        public string Username { get; }
        public int Result { get; }

        public SnapResult(string username, int result)
        {
            Username = username;
            Result = result;
        }
    }
}