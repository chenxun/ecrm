class Role < ActiveRecord::Base
	self.primary_key = 'role_key'
	has_and_belongs_to_many :users
	has_and_belongs_to_many :frames
	validates :role_key, uniqueness: true
end