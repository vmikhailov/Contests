package main

import (
	"reflect"
	"testing"
)

func TestProductExceptSelf(t *testing.T) {
	tests := []struct {
		name string
		nums []int
		want []int
	}{
		{
			name: "basic example 1",
			nums: []int{1, 2, 3, 4},
			want: []int{24, 12, 8, 6},
		},
		{
			name: "basic example 2",
			nums: []int{-1, 1, 0, -3, 3},
			want: []int{0, 0, 9, 0, 0},
		},
		{
			name: "all ones",
			nums: []int{1, 1, 1, 1},
			want: []int{1, 1, 1, 1},
		},
		{
			name: "two elements",
			nums: []int{2, 3},
			want: []int{3, 2},
		},
		{
			name: "with negative numbers",
			nums: []int{-1, -2, -3},
			want: []int{6, 3, 2},
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := productExceptSelf(tt.nums)
			if !reflect.DeepEqual(got, tt.want) {
				t.Errorf("productExceptSelf(%v) = %v, want %v", tt.nums, got, tt.want)
			}
		})
	}
}
