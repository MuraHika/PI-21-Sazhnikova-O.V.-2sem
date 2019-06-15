using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AbstractSecurityShopRestApi.Services
{
    public class WorkWorker
    {
        private readonly IMainService _service;
        private readonly IWorkerService _serviceWorker;
        private readonly int _WorkerId;
        private readonly int _orderId;
        // семафор 
        static Semaphore _sem = new Semaphore(3, 3);
        Thread myThread;
        public WorkWorker(IMainService service, IWorkerService serviceWorker, int WorkerId, int orderId)
        {
            _service = service;
            _serviceWorker = serviceWorker;
            _WorkerId = WorkerId;
            _orderId = orderId;
            try
            {
                _service.Processed(new OrderBindingModel
                {
                    Id = _orderId,
                    WorkerId = _WorkerId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }

        public void Work()
        {
            try
            {
                // забиваем мастерскую 
                _sem.WaitOne();
                // Типа выполняем 
                Thread.Sleep(10000);
                _service.OrderReady(new OrderBindingModel
                {
                    Id = _orderId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую 
                _sem.Release();
            }
        }
    }
}
