using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ComparisionRepository: IComparisionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public ComparisionRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<AppComparision>> GetComparision()
        {
            
             var a =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub klimatyzacja stacjonarnych urządzeń klimatyzacyjnych " && d.Key.Name=="R134a").First();
              
            AppComparision appComparision = new AppComparision(){
                AppUseOfRefrigernatName = a.Key.NameUse,
                AppRefrigernatName = a.Key.Name,
                Weight = (decimal)a.Suma
            };
            


            
             var b =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub konserwacja ruchomych urządzeń klimatyzacyjnych " && d.Key.Name=="R134a").First();
          
            AppComparision appComparision1 = new AppComparision(){
                AppUseOfRefrigernatName = b.Key.NameUse,
                AppRefrigernatName = b.Key.Name,
                Weight = (decimal) b.Suma
            };




            var c =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub klimatyzacja stacjonarnych urządzeń klimatyzacyjnych " && d.Key.Name=="R410a").First();
          
            AppComparision appComparision2 = new AppComparision(){
                AppUseOfRefrigernatName = c.Key.NameUse,
                AppRefrigernatName = c.Key.Name,
                Weight = (decimal) c.Suma
            };
            


            
            var d =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub konserwacja ruchomych urządzeń klimatyzacyjnych" && d.Key.Name=="R410a").First();
          
            AppComparision appComparision3 = new AppComparision(){
                AppUseOfRefrigernatName = d.Key.NameUse,
                AppRefrigernatName = d.Key.Name,
                Weight = (decimal) d.Suma
            };



                 
            var e =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub klimatyzacja stacjonarnych urządzeń klimatyzacyjnych " && d.Key.Name=="R32").First();
          
            AppComparision appComparision4 = new AppComparision(){
                AppUseOfRefrigernatName = e.Key.NameUse,
                AppRefrigernatName = e.Key.Name,
                Weight = (decimal) e.Suma
            };



                 
            var f =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub konserwacja ruchomych urządzeń klimatyzacyjnych " && d.Key.Name=="R32").First();
          
            AppComparision appComparision5 = new AppComparision(){
                AppUseOfRefrigernatName = f.Key.NameUse,
                AppRefrigernatName = f.Key.Name,
                Weight = (decimal) f.Suma
            };
             

            List<AppComparision> en = new List<AppComparision>();
          
            en.Add(appComparision);
            en.Add(appComparision1);
            en.Add(appComparision2);
            en.Add(appComparision3);
            en.Add(appComparision4);
            en.Add(appComparision5);
            
            return en;
        }
    }
}