using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class ToppingDAL
    {
        public List<Topping> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Toppings.ToList();
            }
        }

        public Topping GetById(string maTopping)
        {
            using (var context = new AppDbContext())
            {
                return context.Toppings
                    .FirstOrDefault(x => x.MaTopping == maTopping);
            }
        }

        public List<Topping> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.Toppings
                    .Where(x =>
                        x.MaTopping.Contains(keyword) ||
                        x.TenTopping.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(Topping topping)
        {
            using (var context = new AppDbContext())
            {
                context.Toppings.Add(topping);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Topping topping)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Toppings
                    .FirstOrDefault(x => x.MaTopping == topping.MaTopping);

                if (existing == null)
                    return false;

                existing.TenTopping = topping.TenTopping;
                existing.GiaBan = topping.GiaBan;
                existing.SoLuongTon = topping.SoLuongTon;
                existing.MucCanhBao = topping.MucCanhBao;
                existing.DonViTinh = topping.DonViTinh;
                existing.DonViTinhQuyDoi = topping.DonViTinhQuyDoi;
                existing.HeSoQuyDoi = topping.HeSoQuyDoi;
                existing.TrangThai = topping.TrangThai;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maTopping)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Toppings
                    .FirstOrDefault(x => x.MaTopping == maTopping);

                if (existing == null)
                    return false;

                context.Toppings.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}