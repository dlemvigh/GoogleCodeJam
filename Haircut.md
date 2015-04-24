# Solution idea for [Haircut](https://code.google.com/codejam/contest/4224486/dashboard#s=p1)

Take list of barber speeds.

	M = m1, m2, ..., mB

Calculate proportion of customers handled by each barber.

	sum = M.select(m => 1/m).Sum()
	C = M.select(m => 1 / m / sum)

Distribute guaranteed customers per barber
Math.Floor((N-1) * Ci) * mi

	Cust = C.select(c => Math.floor(c * (N - 1))) 

Simulate from there...   