using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Shared
{
    public class ResultViewModel<T>
    {
        public ResultViewModel() { }

        public ResultViewModel(T data)
        {
            Result = true;
            Data = data;
        }

        public bool Result { get; set; }


        public T Data { get; set; }
    }

    public class ResultsViewModel<T> : ResultViewModel<IEnumerable<T>>
    {
        public ResultsViewModel(IEnumerable<T> data)
        {
            Result = true;
            Data = data;
        }
    }

    public class ResultViewModel
    {
        public ResultViewModel() { }

        public ResultViewModel(bool result, string message = null)
        {
            Result = result;
            Message = message;
        }

        public ResultViewModel(Exception e)
        {
            Result = false;
            Message = e.InnerException?.Message ?? e.Message;
        }

        public bool Result { get; set; }

        public string Message { get; set; }

    }

    public class ResultPaginado<T>
    {
        public ResultPaginado() { }

        public ResultPaginado(IEnumerable<T> data, int total)
        {
            this.Results = data;
            this.Total = total;
        }



        public int Total { get; set; }
        public IEnumerable<T> Results { get; set; }
    }

    public class ImportResult
    {
        public ImportResult()
        {
            MjsErrores = new List<string>();
        }
        public string Mensaje { get; set; }

        public int Total { get; set; }

        public int Errores { get; set; }

        public List<string> MjsErrores { get; set; }

    }
}
