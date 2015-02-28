class Frame < ActiveRecord::Base
	has_and_belongs_to_many :roles
	has_many :pages, class_name: 'Frame', foreign_key: 'parent_id'
	belongs_to :parent, class_name: 'Frame'
end