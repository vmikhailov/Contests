package main

import "testing"

func TestCanPlaceFlowers(t *testing.T) {
	tests := []struct {
		name      string
		flowerbed []int
		n         int
		want      bool
	}{
		{"example1", []int{1, 0, 0, 0, 1}, 1, true},
		{"example2", []int{1, 0, 0, 0, 1}, 2, false},
		{"all zeros small", []int{0}, 1, true},
		{"all zeros small fail", []int{0}, 2, false},
		{"single one n0", []int{1}, 0, true},
		{"single one n1", []int{1}, 1, false},
		{"three zeros two", []int{0, 0, 0}, 2, true},
		{"five zeros three", []int{0, 0, 0, 0, 0}, 3, true},
		{"zeros with center one", []int{0, 0, 1, 0, 0}, 2, true},
		{"zeros with middle occupied", []int{0, 1, 0}, 1, false},
		{"empty bed n0", []int{}, 0, true},
		{"empty bed n1", []int{}, 1, false},
	}

	for _, tc := range tests {
		t.Run(tc.name, func(t *testing.T) {
			got := canPlaceFlowers(tc.flowerbed, tc.n)
			if got != tc.want {
				t.Fatalf("canPlaceFlowers(%v, %d) = %v; want %v", tc.flowerbed, tc.n, got, tc.want)
			}
		})
	}
}
