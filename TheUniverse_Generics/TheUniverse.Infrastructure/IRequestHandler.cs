namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler<Request, Response>
    {
        Response Execute(Request request);
    }
}