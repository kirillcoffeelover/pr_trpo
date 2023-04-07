bin := ./bin/Debug/Mono

src := Forms Panels TabPages Structs DBLib Program
source := $(foreach dir,$(src),$(shell find $(dir) -path '*.cs'))

libs := /lib/mono/4.8-api/System.Windows.Forms.dll

ifeq '$(shell if test -f dlls; then echo yes; fi)' ''
$(error File 'dlls' does not exist)
endif

dlls := $(shell cat dlls | sort)

target := $(bin)/MainApp.exe

cscflags := -t:winexe -debug -nologo $(foreach v,$(libs) $(dlls),$(addprefix -r:,$(v)))

.PHONY:all clean run deps $(dlls)

all: $(target)

run:$(all)
	mono --debug $(target)

$(target): $(bin) $(source) | $(dlls)
	@echo CSC $(notdir $@)
	csc -out:$@ $(cscflags) $(source) 

$(dlls):
	@cp -uf $@ $(bin)/$(notdir $@)

$(bin):
	@mkdir -p $@

clean:
	rm -f $(wildcard $(bin)/*)
