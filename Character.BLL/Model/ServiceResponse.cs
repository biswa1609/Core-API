namespace Character.BLL.Model
{
    public class ServiceResponse<T>
    {
        public T Data {get;set;}
        public bool Response{get;set;} = true;
        public string Message{get;set;} = null;
        
    }
}