class Person < ActiveRecord::Base
	has_one :user
	belongs_to :department
	self.table = 'persons'
end