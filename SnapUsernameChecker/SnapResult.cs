namespace SnapUsernameChecker
{
    public class SnapResult
    {
        public string Username { get; }
        public bool Exists { get; }

        public SnapResult(string username, bool exists)
        {
            Username = username;
            Exists = exists;
        }
    }
}