package main

func canPlaceFlowers(flowerbed []int, n int) bool {
	c := 1

	for i := 0; i < len(flowerbed); i++ {
		if flowerbed[i] == 0 {
			c++
		} else if c > 0 {
			n -= (c - 1) / 2
			c = 0
		}
	}

	if c > 0 {
		n -= c / 2
	}

	return n <= 0
}
