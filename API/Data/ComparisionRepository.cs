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
            
            AppComparision appComparision;
            List<AppComparision> en = new List<AppComparision>();

             var a =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub klimatyzacja stacjonarnych urządzeń klimatyzacyjnych " && d.Key.Name=="R134a").FirstOrDefault();
            
            if(a != null){
                appComparision= new AppComparision(){
                    AppUseOfRefrigernatName = a.Key.NameUse,
                    AppRefrigernatName = a.Key.Name,
                    Weight = a.Suma
                };
                en.Add(appComparision);
            }
             

    
             var b =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub konserwacja ruchomych urządzeń klimatyzacyjnych " && d.Key.Name=="R134a").FirstOrDefault();
            
            if(b != null){
            AppComparision appComparision1 = new AppComparision(){
                AppUseOfRefrigernatName = b.Key.NameUse,
                AppRefrigernatName = b.Key.Name,
                Weight = (decimal) b.Suma
            }; en.Add(appComparision1);
           }




            var c =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub klimatyzacja stacjonarnych urządzeń klimatyzacyjnych " && d.Key.Name=="R410a").FirstOrDefault();
            
            if(c != null){
            AppComparision appComparision2 = new AppComparision(){
                AppUseOfRefrigernatName = c.Key.NameUse,
                AppRefrigernatName = c.Key.Name,
                Weight = (decimal) c.Suma
            };  en.Add(appComparision2);
            }
            


            
            var d =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub konserwacja ruchomych urządzeń klimatyzacyjnych" && d.Key.Name=="R410a").FirstOrDefault();
          if(d != null){
            AppComparision appComparision3 = new AppComparision(){
                AppUseOfRefrigernatName = d.Key.NameUse,
                AppRefrigernatName = d.Key.Name,
                Weight = (decimal) d.Suma
            };
            en.Add(appComparision3);}



                 
            var e =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub klimatyzacja stacjonarnych urządzeń klimatyzacyjnych " && d.Key.Name=="R32").FirstOrDefault();
          if(e != null){
            AppComparision appComparision4 = new AppComparision(){
                AppUseOfRefrigernatName = e.Key.NameUse,
                AppRefrigernatName = e.Key.Name,
                Weight = (decimal) e.Suma
            };en.Add(appComparision4);}



                 
            var f =  _context.Orders.GroupBy(d =>  new{d.AppRefrigerant.Name, d.AppUseOfRefrigernat.NameUse}  )
             .Select(y => new {
                 y.Key, Suma = y.Sum(x => x.Weight)
             } ).Where(d => d.Key.NameUse == "Serwisowanie lub konserwacja ruchomych urządzeń klimatyzacyjnych " && d.Key.Name=="R32").FirstOrDefault();
          if(f != null){
            AppComparision appComparision5 = new AppComparision(){
                AppUseOfRefrigernatName = f.Key.NameUse,
                AppRefrigernatName = f.Key.Name,
                Weight = (decimal) f.Suma
            }; en.Add(appComparision5);}

         return en;
        }
    }
        }