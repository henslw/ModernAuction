using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModernAuction.Data;
using ModernAuction.Models;

namespace ModernAuction.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly AuctionDbContext _context;

        public AuctionsController(AuctionDbContext context)
        {
            _context = context;
        }

        // GET: Auctions
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            //ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            
            var auctions = from s in _context.Auctions
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                auctions = auctions.Where(s => s.Item.ItemDescription.Contains(searchString)
                                       || s.Item.ItemDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    auctions = auctions.OrderByDescending(s => s.Item.ItemDescription);
                    break;
                case "Date":
                    auctions = auctions.OrderBy(s => s.AuctionStartTime);
                    break;
                case "date_desc":
                    auctions = auctions.OrderByDescending(s => s.AuctionStartTime);
                    break;
                default:
                    auctions = auctions.OrderBy(s => s.Item.ItemDescription );
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Auction>.CreateAsync(auctions.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Auctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Item)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AuctionID == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // GET: Auctions/Create
        public IActionResult Create()
        {
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemDescription");
            return View();
        }

        // POST: Auctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuctionID,AuctionStartTime,AuctionEndTime,FinalPrice,Currentprice,Bids,AuctionActive,ItemID")] Auction auction)
        {
            try { 

            if (ModelState.IsValid)
            {
                _context.Add(auction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            }
            catch
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            //ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemDescription", auction.ItemID);
            return View(auction);
        }

        // GET: Auctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemDescription", auction.ItemID);
            return View(auction);
        }

        // POST: Auctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var auctionToUpdate = await _context.Auctions.FirstOrDefaultAsync(s => s.AuctionID == id);
            if (await TryUpdateModelAsync<Auction>(
                auctionToUpdate,
                "",
                 s => s.AuctionID, s => s.AuctionStartTime, s => s.AuctionEndTime, s => s.FinalPrice, s => s.Currentprice, s => s.Bids, s => s.AuctionActive, s => s.ItemID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(auctionToUpdate);
        }

        // GET: Auctions/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .AsNoTracking()
                .Include(a => a.Item)
                .FirstOrDefaultAsync(m => m.AuctionID == id);
            if (auction == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(auction);
        }

        // POST: Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Auctions == null)
            //{
            //    return Problem("Entity set 'AuctionDbContext.Auctions'  is null.");
            //}
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool AuctionExists(int id)
        {
          return _context.Auctions.Any(e => e.AuctionID == id);
        }
    }
}
