class VisitRecord < ActiveRecord::Base
	belongs_to :customer
	belongs_to :user
end