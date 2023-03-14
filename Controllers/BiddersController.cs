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
    public class BiddersController : Controller
    {
        private readonly AuctionDbContext _context;

        public BiddersController(AuctionDbContext context)
        {
            _context = context;
        }

        // GET: Bidders
        public async Task<IActionResult> Index()
        {
              return View(await _context.Bidders.ToListAsync());
        }

        // GET: Bidders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bidders == null)
            {
                return NotFound();
            }

            var bidder = await _context.Bidders
                .FirstOrDefaultAsync(m => m.BidderID == id);
            if (bidder == null)
            {
                return NotFound();
            }

            return View(bidder);
        }

        // GET: Bidders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bidders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BidderID,BidderUserID,AuctionID,BidAmount")] Bidder bidder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bidder);
        }

        // GET: Bidders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bidders == null)
            {
                return NotFound();
            }

            var bidder = await _context.Bidders.FindAsync(id);
            if (bidder == null)
            {
                return NotFound();
            }
            return View(bidder);
        }

        // POST: Bidders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BidderID,BidderUserID,AuctionID,BidAmount")] Bidder bidder)
        {
            if (id != bidder.BidderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidderExists(bidder.BidderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bidder);
        }

        // GET: Bidders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bidders == null)
            {
                return NotFound();
            }

            var bidder = await _context.Bidders
                .FirstOrDefaultAsync(m => m.BidderID == id);
            if (bidder == null)
            {
                return NotFound();
            }

            return View(bidder);
        }

        // POST: Bidders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bidders == null)
            {
                return Problem("Entity set 'AuctionDbContext.Bidders'  is null.");
            }
            var bidder = await _context.Bidders.FindAsync(id);
            if (bidder != null)
            {
                _context.Bidders.Remove(bidder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidderExists(int id)
        {
          return _context.Bidders.Any(e => e.BidderID == id);
        }
    }
}
